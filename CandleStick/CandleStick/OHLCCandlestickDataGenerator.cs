using System.Diagnostics.Metrics;
using System.Drawing;

namespace CandleStick
{
    public class OHLCCandlestickDataGenerator
    {

        ICandlestickDataInput _candlestickDataInput;

        public OHLCCandlestickDataGenerator(ICandlestickDataInput candlestickDataInput) {
            _candlestickDataInput = candlestickDataInput;
        }

        public OHLCCandlestickDataGenerator()
        {
            _candlestickDataInput = new MockCandlestickDataInput();
        }

        public List<Candlestick> CreateCandlesticks(TimeSpan interval)
        {
            return CreateCandlesticks(_candlestickDataInput.GetTimeStream(), interval);
        }

        public List<Candlestick> CreateCandlesticks(Dictionary<DateTime, float> timestream, TimeSpan interval){

            List<Candlestick> candlesticks = new List<Candlestick>();

            var groupedTimes = 
                from datetimes in timestream
                group datetimes by datetimes.Key.Ticks / interval.Ticks
                into groups
                    select new { 
                        startTime = new DateTime(groups.Key * interval.Ticks), 
                        endTime = new DateTime(groups.Key * (interval.Ticks) + interval.Ticks - 1), 
                        Values = groups
                    };

            foreach (var span in groupedTimes)
            {
                Candlestick candlestick = new Candlestick();
                candlestick.StartTime = span.startTime;
                candlestick.EndTime = span.endTime;
                DateTime minTime = DateTime.MaxValue;
                DateTime maxTime = DateTime.MinValue;
                foreach(var point in span.Values)
                {
                    if (!candlestick.HasData)
                    {
                        InitialiseCandlestickWithPointValue(candlestick, point.Value);
                    }
                    if(point.Key > maxTime)
                    {
                        maxTime = point.Key;
                        candlestick.CloseValue = point.Value;
                    }
                    if (point.Key < minTime)
                    {
                        minTime = point.Key;
                        candlestick.OpenValue = point.Value;
                    }
                    if(candlestick.LowValue > point.Value)
                    {
                        candlestick.LowValue = point.Value;
                    }
                    if(candlestick.HighValue < point.Value)
                    {
                        candlestick.HighValue = point.Value;
                    }
                }

                candlesticks.Add(candlestick);
            }

            return candlesticks;
        }

        private void InitialiseCandlestickWithPointValue(Candlestick candlestick, float value)
        {
            candlestick.HasData = true;
            candlestick.LowValue = value;
            candlestick.OpenValue = value;
            candlestick.CloseValue = value;
            candlestick.HighValue = value;
        }

    }
}