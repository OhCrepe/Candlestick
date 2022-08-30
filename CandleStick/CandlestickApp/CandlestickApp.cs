using CandleStick;

namespace CandlestickApp
{
    public class CandlestickApp
    {

        // TODO - Potential things to consider in the future
        // What if there's a time frame where data is missing?
        // Output on a graph
        // Input provided via file or API call

        static void Main(string[] args)
        {

            TimeSpan granularity = new TimeSpan(1, 0, 0);

            OHLCCandlestickDataGenerator candlestickGenerator = new OHLCCandlestickDataGenerator();
            List<Candlestick> candlesticks = candlestickGenerator.CreateCandlesticks(granularity);

            OutputCandlesticks(candlesticks);

            Console.WriteLine("\nConsole will close when you press enter...");
            Console.ReadLine();

        }

        private static void OutputCandlesticks(List<Candlestick> candlesticks)
        {
            foreach(Candlestick candlestick in candlesticks)
            {
                Console.WriteLine("\n### Candlestick ###");
                Console.WriteLine("Start Time: " + candlestick.StartTime);
                Console.WriteLine("End Time: " + candlestick.EndTime);
                if (candlestick.HasData)
                {

                    Console.WriteLine("Open Value: " + candlestick.OpenValue);
                    Console.WriteLine("Close Value: " + candlestick.CloseValue);
                    Console.WriteLine("High Value: " + candlestick.HighValue);
                    Console.WriteLine("Low Value: " + candlestick.LowValue);
                }
                else
                {
                    Console.WriteLine("NO DATA");
                }
            }
        }
    }
}
