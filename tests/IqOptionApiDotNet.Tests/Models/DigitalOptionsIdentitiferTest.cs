using System;
using FluentAssertions;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Models.DigitalOptions;
using NUnit.Framework;

namespace IqOptionApiDotNet.Tests.Models
{
    [TestFixture]
    public class DigitalOptionsIdentifierTest
    {
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