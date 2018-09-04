using System;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

[TestFixture]
public class ConcurrentExecutionOne
{
    /*
     * Exercise:
     *  Create an enumerable for four tasks that use `Task.Delay` and await the first that completes
     *  What behavior do you observe and how is different from executing normal synchronous code?
     *
     * Bonus:
     *  - Combine what you did in exercise `ConcurrentExecutionAll` with this approach and continue if a certain timeout is reached. Implement without Cancellation support
     *  - What are the consequences of the code you wrote above during runtime?
     *
     * Hint:
     *  - You can use `PrintCurrentThread` or other Helpers to print i.ex. the current managed thread ID
     *  - `Enumerable.Range` allows you to easily create enumerable with multiple entries
     *  - Look into `Task.WhenAny`
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