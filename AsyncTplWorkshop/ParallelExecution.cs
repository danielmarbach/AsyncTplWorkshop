using System;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

[TestFixture]
public class ParallelExecution
{
    /*
     * Exercise:
     *  Create an enumerable for four tasks that use `Thread.Sleep` and await all of them in parallel
     *  What kind of task do you need to execute this code?
     *
     * Hint:
     *  - You can use `PrintCurrentThread` or other Helpers to print i.ex. the current managed thread ID
     *  - `Enumerable.Range` allows you to easily create enumerable with multiple entries
     *  - Look into `Task.WhenAll`
     */
    private Task ImplementHere()
    {
        // TODO
        return Task.CompletedTask;
    }

    [Test]
    public Task Run()
    {
        return ImplementHere().TaskState();
    }
}