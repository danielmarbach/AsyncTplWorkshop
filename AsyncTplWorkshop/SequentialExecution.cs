using System;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

[TestFixture]
public class SequentialExecution
{
    /*
     * Exercise:
     *  Create an enumerable for four tasks that use `Task.Delay` and await each of them sequentially
     *  What behavior do you observe and how is different from executing normal synchronous code?
     *
     * Bonus:
     *  - What happens when you materialize the list vs don't materialize the list and why?
     *  - Let one of the operations fails, what is the behavior that you observe?
     *
     * Hint:
     *  - You can use `PrintCurrentThread` or other Helpers to print i.ex. the current managed thread ID
     *  - `Enumerable.Range` allows you to easily create enumerable with multiple entries
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