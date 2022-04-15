using System;
using FluentAssertions;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.unit;
using Newtonsoft.Json;
using NUnit.Framework;

namespace IqOptionApiDotNet.Tests.JsonTest {
    
    [TestFixture]
    public class ServerTimeTest : TestFor<LoadJsonFileTest> {

        private string Json;
        
        [SetUp]
        public void TestSetup() {

            Json = CreateUnit().LoadJson("Json/timesync.json");
            Json.Should().NotBeEmpty();
        }


        [Test]
        public void GetTimeSync_WithExistingValue_DateTimeOffsetConvertedCorrected() {

            // act
            var result = JsonConvert.DeserializeObject<ServerTime>(Json);

            // assert
            var dt = DateTimeOffset.FromUnixTimeMilliseconds(1534749220468);

            result.Should().NotBeNull();
            result.ServerTick.Should().Be(dt);
        }
    }
}