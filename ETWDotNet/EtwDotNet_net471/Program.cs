using System;
using System.Diagnostics;
using System.Threading;
using System.Diagnostics.Tracing;

namespace EtwDotNet_net471
{
    internal class Program
    {
        private static readonly EventSource MyLogger = new EventSource(eventSourceName: "Microsoft-EtwDemo");

        public static void Main(string[] args)
        {
            var stopwatch = Stopwatch.StartNew();
            RunApp("EtwDotNet");
            stopwatch.Stop();
/*
 *
 * The smallest unit of time is the tick, which is equal to 100 nanoseconds or one ten-millionth of a second.
 * There are 10,000 ticks in a millisecond.
 * The value of the Ticks property can be negative or positive to represent a negative or positive time interval.
 */
            Console.WriteLine($"EtwDotNet: {stopwatch.Elapsed.Ticks * 100} nanosec per iteration");
        }

        private static int RunApp(string stringData)
        {
            Console.WriteLine($"EventSource: {MyLogger.Guid}/ {MyLogger.Name}");
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
