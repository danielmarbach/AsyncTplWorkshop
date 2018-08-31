using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

public static class Helpers
{
    public static void PrintCurrentThread(this object value)
    {
        Console.WriteLine($"-- Current Thread {Thread.CurrentThread.ManagedThreadId}");
    }

    public static async Task TaskState(this Task task)
    {
        PrintCurrentThread(null);
        var stopWatch = Stopwatch.StartNew();
        try
        {
            Console.WriteLine($"-- Task state before '{task.Status}'");
            Console.WriteLine();
            await task.ConfigureAwait(false);
        }
        finally
        {
            stopWatch.Stop();
            Console.WriteLine($"-- Task state: {task.Status}");
            Console.WriteLine($"-- Execution time: {stopWatch.Elapsed}");
            PrintCurrentThread(null);
        }
    }
}