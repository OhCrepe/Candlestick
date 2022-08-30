global using NUnit.Framework;
using CandleStick;

namespace CandleStickTests
{
    public class CandleStickTests
    {

        [Test]
        public void SingleCandlestickReturnsCorrectValues()
        {
            Dictionary<DateTime, float> timestream = new Dictionary<DateTime, float>();
            timestream.Add(new DateTime(2000, 1, 1, 12, 0, 4), 4f);
            timestream.Add(new DateTime(2000, 1, 1, 12, 59, 4), 6f);
            timestream.Add(new DateTime(2000, 1, 1, 12, 6, 4), 3f);
            timestream.Add(new DateTime(2000, 1, 1, 12, 23, 12), 8f);


            TimeSpan granularity = new TimeSpan(1, 0, 0);;

            OHLCCandlestickDataGenerator candlestickGenerator = new OHLCCandlestickDataGenerator();
            List<Candlestick> candlesticks = candlestickGenerator.CreateCandlesticks(timestream, granularity);


            Assert.That(candlesticks.Count, Is.EqualTo(1));
            Assert.That(candlesticks[0].StartTime, Is.EqualTo(new DateTime(2000, 1, 1, 12, 0, 0)));
            Assert.That(candlesticks[0].EndTime, Is.EqualTo(new DateTime(2000, 1, 1, 13, 0, 0).AddTicks(-1)));
            Assert.That(candlesticks[0].OpenValue, Is.EqualTo(4f));
            Assert.That(candlesticks[0].CloseValue, Is.EqualTo(6f));
            Assert.That(candlesticks[0].HighValue, Is.EqualTo(8f));
            Assert.That(candlesticks[0].LowValue, Is.EqualTo(3f));

        }

        [Test]
        public void MultipleCandlesticksReturnsCorrectValues()
        {
            Dictionary<DateTime, float> timestream = new Dictionary<DateTime, float>();
            timestream.Add(new DateTime(2000, 1, 1, 12, 0, 4), 4f);
            timestream.Add(new DateTime(2000, 1, 1, 12, 59, 4), 6f);
            timestream.Add(new DateTime(2000, 1, 1, 12, 6, 4), 3f);
            timestream.Add(new DateTime(2000, 1, 1, 12, 23, 12), 8f);
            timestream.Add(new DateTime(2000, 1, 1, 13, 1, 4), 6f);
            timestream.Add(new DateTime(2000, 1, 1, 13, 59, 4), 10f);
            timestream.Add(new DateTime(2000, 1, 1, 13, 6, 4), 4f);
            timestream.Add(new DateTime(2000, 1, 1, 13, 53, 12), 11f);
            timestream.Add(new DateTime(2000, 1, 1, 14, 1, 4), 10f);
            timestream.Add(new DateTime(2000, 1, 1, 14, 59, 4), 7f);
            timestream.Add(new DateTime(2000, 1, 1, 14, 6, 4), 1f);
            timestream.Add(new DateTime(2000, 1, 1, 14, 53, 12), 12f);


            TimeSpan granularity = new TimeSpan(1, 0, 0); ;

            OHLCCandlestickDataGenerator candlestickGenerator = new OHLCCandlestickDataGenerator();
            List<Candlestick> candlesticks = candlestickGenerator.CreateCandlesticks(timestream, granularity);


            Assert.That(candlesticks.Count, Is.EqualTo(3));
            Assert.That(candlesticks[0].StartTime, Is.EqualTo(new DateTime(2000, 1, 1, 12, 0, 0)));
            Assert.That(candlesticks[0].EndTime, Is.EqualTo(new DateTime(2000, 1, 1, 13, 0, 0).AddTicks(-1)));
            Assert.That(candlesticks[0].OpenValue, Is.EqualTo(4f));
            Assert.That(candlesticks[0].CloseValue, Is.EqualTo(6f));
            Assert.That(candlesticks[0].HighValue, Is.EqualTo(8f));
            Assert.That(candlesticks[0].LowValue, Is.EqualTo(3f));

            Assert.That(candlesticks[1].StartTime, Is.EqualTo(new DateTime(2000, 1, 1, 13, 0, 0)));
            Assert.That(candlesticks[1].EndTime, Is.EqualTo(new DateTime(2000, 1, 1, 14, 0, 0).AddTicks(-1)));
            Assert.That(candlesticks[1].OpenValue, Is.EqualTo(6f));
            Assert.That(candlesticks[1].CloseValue, Is.EqualTo(10f));
            Assert.That(candlesticks[1].HighValue, Is.EqualTo(11f));
            Assert.That(candlesticks[1].LowValue, Is.EqualTo(4f));

            Assert.That(candlesticks[2].StartTime, Is.EqualTo(new DateTime(2000, 1, 1, 14, 0, 0)));
            Assert.That(candlesticks[2].EndTime, Is.EqualTo(new DateTime(2000, 1, 1, 15, 0, 0).AddTicks(-1)));
            Assert.That(candlesticks[2].OpenValue, Is.EqualTo(10f));
            Assert.That(candlesticks[2].CloseValue, Is.EqualTo(7f));
            Assert.That(candlesticks[2].HighValue, Is.EqualTo(12f));
            Assert.That(candlesticks[2].LowValue, Is.EqualTo(1f));

        }

        [Test]
        public void MinuteLongGranularityReturnsCorrectValues()
        {
            Dictionary<DateTime, float> timestream = new Dictionary<DateTime, float>();
            timestream.Add(new DateTime(2000, 1, 1, 12, 10, 4), 4f);
            timestream.Add(new DateTime(2000, 1, 1, 12, 10, 50), 6f);
            timestream.Add(new DateTime(2000, 1, 1, 12, 10, 30), 3f);
            timestream.Add(new DateTime(2000, 1, 1, 12, 10, 12), 8f);
            timestream.Add(new DateTime(2000, 1, 1, 12, 11, 4), 6f);
            timestream.Add(new DateTime(2000, 1, 1, 12, 11, 51), 10f);
            timestream.Add(new DateTime(2000, 1, 1, 12, 11, 34), 4f);
            timestream.Add(new DateTime(2000, 1, 1, 12, 11, 11), 11f);


            TimeSpan granularity = new TimeSpan(0, 1, 0); ;


            OHLCCandlestickDataGenerator candlestickGenerator = new OHLCCandlestickDataGenerator();
            List<Candlestick> candlesticks = candlestickGenerator.CreateCandlesticks(timestream, granularity);


            Assert.That(candlesticks.Count, Is.EqualTo(2));
            Assert.That(candlesticks[0].StartTime, Is.EqualTo(new DateTime(2000, 1, 1, 12, 10, 0)));
            Assert.That(candlesticks[0].EndTime, Is.EqualTo(new DateTime(2000, 1, 1, 12, 11, 0).AddTicks(-1)));
            Assert.That(candlesticks[0].OpenValue, Is.EqualTo(4f));
            Assert.That(candlesticks[0].CloseValue, Is.EqualTo(6f));
            Assert.That(candlesticks[0].HighValue, Is.EqualTo(8f));
            Assert.That(candlesticks[0].LowValue, Is.EqualTo(3f));

            Assert.That(candlesticks[1].StartTime, Is.EqualTo(new DateTime(2000, 1, 1, 12, 11, 0)));
            Assert.That(candlesticks[1].EndTime, Is.EqualTo(new DateTime(2000, 1, 1, 12, 12, 0).AddTicks(-1)));
            Assert.That(candlesticks[1].OpenValue, Is.EqualTo(6f));
            Assert.That(candlesticks[1].CloseValue, Is.EqualTo(10f));
            Assert.That(candlesticks[1].HighValue, Is.EqualTo(11f));
            Assert.That(candlesticks[1].LowValue, Is.EqualTo(4f));

        }

    }
}