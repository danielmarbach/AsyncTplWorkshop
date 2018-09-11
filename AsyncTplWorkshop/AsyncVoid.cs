using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

[TestFixture]
public class AsyncVoid
{
    /*
     * Exercise:
     *  Implement an async void method that throws an exception
     *  Add Console statements to the code to see what is going on
     *  What happens from the perspective of the caller? Can you observe the exception?
     *  Add a `Task.Delay` before the throw, does it change the execution time of the test?
     *
     * Bonus:
     *  - Replace `Task.Delay` with `Thread.Sleep`. What happens? Can you explain this?
     *    Change the return type to Task and execute again
     *
     * Hint:
     *  - You can use `PrintCurrentThread` or other Helpers to print i.ex. the current managed thread ID
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