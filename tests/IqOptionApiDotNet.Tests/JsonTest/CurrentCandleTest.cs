﻿using FluentAssertions;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.unit;
using IqOptionApiDotNet.Ws;
using Newtonsoft.Json;
using NUnit.Framework;

namespace IqOptionApiDotNet.Tests.JsonTest {
    public class CurrentCandleTest : TestFor<LoadJsonFileTest> {
        
        private string Json { get; set; }

        [SetUp]
        public void TestSetup() {

            Json = CreateUnit().LoadJson("Json/subscribeMessage/candle-generated.json");
            Json.Should().NotBeEmpty();
        }

        [Test]
        public void GetCandlesResult_WithFromAndTo_DateTimeMustSetCorrectly() {

            //act
            var result = JsonConvert.DeserializeObject<CurrentCandleInfoResultMessage>(Json);

            // assert
            result.Should().NotBeNull();

            var candles = result.Message;
            candles.Should().NotBeNull();
            candles.ActivePair.Should().Be(ActivePair.EURUSD);

            candles.Max.Should().Be(1.14107);
            candles.Min.Should().Be(1.141035);

            candles.Bid.Should().Be(1.14099);
            candles.Ask.Should().Be(1.14115);

            candles.Open.Should().Be(1.141055);
            candles.Close.Should().Be(1.14107);

            candles.From.Year.Should().Be(2018);
            candles.From.Month.Should().Be(08);
            candles.From.Day.Should().Be(20);


            candles.To.Year.Should().Be(2018);
            candles.To.Month.Should().Be(08);
            candles.To.Day.Should().Be(20);


        }
    }
}