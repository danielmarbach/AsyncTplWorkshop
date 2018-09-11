using System;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

[TestFixture]
public class CancelTaskOperation
{
    /*
     * Exercise:
     *  Create a `CancellationTokenSource` that cancels after some period of time and pass the token to `Task.Delay`
     *  Discuss with your peers what happens to the task and how the cancellation token influences the task
     *  What is the effect on the caller that awaits the task returned?
     *  If you want to support cancellation in your APIs what does that mean for your API?
     *  What is the connection between a CancellationTokenSource and a token?
     *  Any ideas why a token is a struct and not a class?
     *
     * Bonus:
     *
     * - Graceful behavior: Implement an extension method that removes the side effect discussed above from the caller that
     *  awaits the canceled `Task.Delay`
     * - Explore default(CancellationToken) and how it behaves
     *
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