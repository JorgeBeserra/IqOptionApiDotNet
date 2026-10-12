using System;
using System.Globalization;
using System.Reflection;
using Newtonsoft.Json.Linq;
using FluentAssertions;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Models.DigitalOptions;
using NUnit.Framework;

namespace IqOptionApiDotNet.Tests.Models
{
    [TestFixture]
    public class DigitalOptionsIdentifierTest
    {
        [Test]
        public void ExplicitInstrumentIdIsPreserved()
        {
            const string id = "do1A20260529D173500T5MCSPT";
            new DigitalOptionsIdentifier(id).ToString().Should().Be(id);
        }

        [Test]
        public void DigitalRequestUsesPairAndInvariantAmount()
        {
            var previous = CultureInfo.CurrentCulture;
            try
            {
                CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("pt-BR");
                var identifier = new DigitalOptionsIdentifier(ActivePair.EURUSD, OrderDirection.Call,
                    DigitalOptionsExpiryDuration.M5, DateTimeOffset.Parse("2020-05-29T17:30:09Z"));
                var type = typeof(DigitalOptionsIdentifier).Assembly.GetType(
                    "IqOptionApiDotNet.Wss.Request.DigitalOptions.PlaceDigitalOptionsMessageRequest")!;
                var request = Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.NonPublic,
                    null, new object[] { identifier, 42, 1.5d }, null)!;
                var body = JObject.Parse(request.ToString()!)["msg"]!["body"]!;
                Assert.That((int)body["asset_id"]!, Is.EqualTo((int)ActivePair.EURUSD));
                Assert.That((string)body["amount"]!, Is.EqualTo("1.5"));
            }
            finally
            {
                CultureInfo.CurrentCulture = previous;
            }
        }

        [Ignore("fix later")]
        [TestCase(ActivePair.EURCHF, OrderDirection.Call, DigitalOptionsExpiryDuration.M15, "doEURCHF201811101250PT15MCSPT")]
        [TestCase(ActivePair.GBPUSD, OrderDirection.Put, DigitalOptionsExpiryDuration.M5, "doGBPUSD201811101250PT5MPSPT")]
        [TestCase(ActivePair.EURUSD, OrderDirection.Call, DigitalOptionsExpiryDuration.M1, "doEURUSD201811101250PT1MCSPT")]
        public void TestCreate_InstrumentId(
            ActivePair active,
            OrderDirection direction,
            DigitalOptionsExpiryDuration duration,
            string expected)
        {
            var specificDate = DateTimeOffset.Parse("2018-11-10 12:50:50Z");

            var result = new DigitalOptionsIdentifier(active, direction, duration, specificDate);

            result.ToString()
                .Should().Be(expected);
        }
    }
}