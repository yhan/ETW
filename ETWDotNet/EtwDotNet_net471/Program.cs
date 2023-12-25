using System;
using System.Diagnostics;
using System.Threading;
using System.Diagnostics.Tracing;

namespace EtwDotNet_net471
{
    internal class Program
    {
        public static readonly EventSource MyLogger = new EventSource("Microsoft-EtwDemo");

        public static void Main(string[] args)
        {
            var stopwatch = Stopwatch.StartNew();
            RunApp("EtwDotNet");
            stopwatch.Stop();

            Console.WriteLine($"EtwDotNet: {stopwatch.Elapsed.Ticks / 100} nanosec per iteration");
        }

        private static int RunApp(string stringData)
        {
            int counter = 0;
            for (int i = 0; i < 1000; i++)
            {
                Interlocked.Increment(ref counter);
                MyLogger.Write(
                    "EventName",
                    new EventSourceOptions { Level = EventLevel.Informational },
                    new { StringVal = stringData, 
                        CounterVal = counter  }
                );
            }
            return counter;
        }
    }
}
