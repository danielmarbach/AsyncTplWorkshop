using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

public static class Helpers
{
    static LimitedConcurrencyLevelTaskScheduler scheduler = new LimitedConcurrencyLevelTaskScheduler(1);

    public static void PrintCurrentThread(this object value, string message = null)
    {
        Console.WriteLine($"-- Current Thread {Thread.CurrentThread.ManagedThreadId}. {message}");
    }

    public static void PrintCurrentContext(this object runnable, string message = null)
    {
        var visible = TaskScheduler.Current == scheduler ? "visible" : "not visible";
        Console.WriteLine($"--  Context is '{visible}'. {message}");
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

    public static Task WrapInContext(this object value, Func<Task> action)
    {
        return Task.Factory.StartNew(() =>
        {
            return action();
        }, CancellationToken.None, TaskCreationOptions.None, scheduler)
        .Unwrap();
    }
}