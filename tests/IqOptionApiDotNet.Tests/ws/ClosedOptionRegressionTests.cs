using System;
using System.Reflection;
using System.Reactive.Linq;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Ws;
using IqOptionApiDotNet.Ws.Base;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace IqOptionApiDotNet.Tests.ws
{
    public class ClosedOptionRegressionTests
    {
        private sealed class OfflineClient : IqOptionWebSocketClient
        {
            public OfflineClient() : base("offline") { }
            protected override void InitialSocket(string secureToken) { }
        }

        [TestCase(true)]
        [TestCase(false)]
        public void SetOptionsUsesTheTopLevelProtocolCommand(bool enabled)
        {
            var type = typeof(IqOptionWebSocketClient).Assembly.GetType(
                "IqOptionApiDotNet.Ws.Request.SetOptionsRequestMessage")!;
            var request = (IWsIqOptionMessageCreator)Activator.CreateInstance(type, new object[] { enabled })!;
            var payload = JObject.Parse(request.CreateIqOptionMessage("results-1"));
            Assert.That((string)payload["name"]!, Is.EqualTo("setOptions"));
            Assert.That((string)payload["request_id"]!, Is.EqualTo("results-1"));
            Assert.That((bool)payload["msg"]!["sendResults"]!, Is.EqualTo(enabled));
        }

        [TestCase("win", OrderResult.Win)]
        [TestCase("loose", OrderResult.Loose)]
        [TestCase("equal", OrderResult.Equal)]
        public void IncomingOptionClosedReachesTheExistingObservable(string result, OrderResult expected)
        {
            using var client = new OfflineClient();
            OptionClosed? received = null;
            using var subscription = client.ClosedOptionObservable().Subscribe(value => received = value);
            var dispatch = typeof(IqOptionWebSocketClient).GetMethod("SubscribeIncomingMessage",
                BindingFlags.Instance | BindingFlags.NonPublic)!;
            dispatch.Invoke(client, new object[] {
                "{\"name\":\"option-closed\",\"msg\":{\"option_id\":12345,\"user_id\":7,\"balance_id\":42,\"amount\":2,\"result\":\"" + result + "\",\"actual_expire\":1700000000}}"
            });
            Assert.That(received, Is.Not.Null);
            Assert.That(received!.OptionId, Is.EqualTo(12345));
            Assert.That(received.BalanceId, Is.EqualTo(42));
            Assert.That(received.Result, Is.EqualTo(expected));
        }
    }
}
