using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandleStick
{
    public class Candlestick
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public float OpenValue { get; set; }
        public float CloseValue { get; set; }
        public float HighValue { get; set; }
        public float LowValue { get; set; }
        public bool HasData { get; set; }
    }
}
