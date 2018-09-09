using System;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

[TestFixture]
public class CancelTask
{
    /*
     * Exercise:
     *  Create a cancelled `CancellationToken` and pass it to a `Task.Run` with an empty body
     *  Discuss with your peers what happens to the task and how the cancellation token influences the task
     *  What is the effect of the token to the body that is executed inside the `Task.Run`?
     *  What is the effect on the caller that awaits the task returned?
     *
     * Bonus:
     *
     *  As a framework or library author would you ever want to pass the cancellation token to the `Task.Run` method
     *  Regardless of the decision above try to backup your reasoning with more than just yes or no ;)
     *
     * Hint:
     *  - You don't need a `CancellationTokenSource` yet
     *  - An empty body can be an method that does nothing
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