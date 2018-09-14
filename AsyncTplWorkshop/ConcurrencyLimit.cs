using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

[TestFixture]
public class ConcurrencyLimit
{
    /*
     * Exercise:
     *  Create three parallel operations that try to access `CriticalRegionThatCanOnlyBeEnteredByOneOperationAtTheSameTime`.
     *  Use a SemaphoreSlim to implement an asynchronous lock so that only one operation at the same time enters the above
     *  mentioned critical region.
     *  Make sure the test is done when all operations are done
     *
     * Bonus:
     *  -  Implement some kind of an SLA that makes sure the operations don't wait indefinitely until the lock is available
     *  -  For fun and profit try to implement a structure that can be used as an asynchronous lock in a using block
     *
     * Hint:
     *  - The semaphore has to be acquired and released
     */
    private Task ImplementHere()
    {
        return Task.CompletedTask;
    }

    private int counter;

    private async Task CriticalRegionThatCanOnlyBeEnteredByOneOperationAtTheSameTime()
    {
        Console.WriteLine("Enter critical region");
        await Task.Delay(500).ConfigureAwait(false); // simulate work
        counter++;
        Console.WriteLine("Exit critical region");
    }

    [Test]
    public Task Run()
    {
        return ImplementHere().TaskState();
    }
}