using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandleStick
{
    internal class MockCandlestickDataInput : ICandlestickDataInput
    {
        public Dictionary<DateTime, float> GetTimeStream()
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
            timestream.Add(new DateTime(2000, 1, 1, 14, 50, 4), 6f);
            timestream.Add(new DateTime(2000, 1, 1, 14, 9, 4), 11f);
            timestream.Add(new DateTime(2000, 1, 1, 14, 53, 12), 12f);

            return timestream;

        }
    }
}
