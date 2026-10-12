using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Ws;
using NUnit.Framework;

namespace IqOptionApiDotNet.Tests.ws
{
    public class BalanceRegressionTests
    {
        private sealed class OfflineClient : IqOptionWebSocketClient
        {
            public OfflineClient() : base("offline") { }
            protected override void InitialSocket(string secureToken) { }
        }

        [Test]
        public void BalancesAreStoredBeforeObserversAreNotified()
        {
            using var client = new OfflineClient();
            typeof(IqOptionWebSocketClient).GetProperty("Profile")!.SetValue(client,
                new Profile.ProfileResult { BalanceId = 42 });
            var balance = new Balance { Id = 42, Type = BalanceType.Practice, Amount = 123.45m };
            using var subscription = client.BalancesObservable.Subscribe(value =>
            {
                Assert.That(client.balances.Single(), Is.SameAs(balance));
                Assert.That(client.Profile.Balance, Is.EqualTo(123.45m));
            });
            client.Subscribe(new[] { balance });
            Assert.That(client.Profile.Balances.Single(), Is.SameAs(balance));
        }

        [Test]
        public void MissingRequestedBalanceHasAnExplicitError()
        {
            using var client = new OfflineClient();
            client.Subscribe(Array.Empty<Balance>());
            var error = Assert.Throws<InvalidOperationException>(() => client.BuyAsync(
                "buy", BalanceType.Practice, ActivePair.EURUSD, 1m,
                OrderDirection.Call, DateTimeOffset.UtcNow.AddMinutes(1)));
            Assert.That(error!.Message, Does.Contain("Practice"));
        }

        [Test]
        public void NullBalanceResponseBecomesAnEmptyCollection()
        {
            using var client = new OfflineClient();
            client.Subscribe((IEnumerable<Balance>)null!);
            Assert.That(client.balances, Is.Empty);
        }
    }
}
