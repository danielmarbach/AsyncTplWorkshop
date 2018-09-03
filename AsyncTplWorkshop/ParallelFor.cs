using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

[TestFixture]
public class ParallelFor
{
    /*
     * Exercise:
     *  Use `Parallel.For` in combination with `CpuBound.Compute` to sort multiple arrays of size 10..15 in parallel
     *  Limit the parallelism to 4
     *  Discuss with your peers what happens and why
     *  Play with the parallelism constraints
     *
     * Bonus:
     *  - What happens to the thread of execution, is it blocked or not?
     *  - What could you change to address the above effect?
     *  - What sort of magic is Parallel.For using behind the scenes to take the above change into account?
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