// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

var stopwatch = Stopwatch.StartNew();
RunApp("EtwDotNet");
stopwatch.Stop();

Console.WriteLine($"EtwDotNet: {stopwatch.Elapsed.Nanoseconds} nanoseconds per iteration");

int RunApp(string stringData)
{
    int counter = 0;
    for (int i = 0; i < 1000; i++)
    {
        Interlocked.Increment(ref counter);
    }
    return counter;
}