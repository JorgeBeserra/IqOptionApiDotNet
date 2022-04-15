using FluentAssertions;
using IqOptionApiDotNet.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace IqOptionApiDotNet.Tests.JsonTest.Instruments
{
    public class GetInstrument_ForexResult_Test : TestFor<LoadJsonFileTest>
    {
        
        private string Json;
        
        [SetUp]
        public void TestSetup() {

            Json = CreateUnit().LoadJson("Json/Instruments/forex.json");
            Json.Should().NotBeEmpty();
        }

        [Test]
        public void Test()
        {
            // arrange
            var instrumentResult = JsonConvert.DeserializeObject<InstrumentsResult>(Json);
            
            // assert
            instrumentResult.Should().NotBeNull();
            instrumentResult.Name.Should().Be("instruments");
            instrumentResult.Message.Should().NotBeNull();
            instrumentResult.Message.Type.Should().Be(InstrumentType.Forex);
        }
    }
}