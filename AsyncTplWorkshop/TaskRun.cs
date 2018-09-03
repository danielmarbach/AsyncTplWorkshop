using System;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

[TestFixture]
public class TaskRun
{
    /*
     * Exercise:
     *  Use `Task.Run` in combination with `CpuBound.Compute` to sort one array of size 10..13 in parallel
     *  Discuss with your peers what happens and why
     *
     * Bonus:
     *  - What happens to the thread of execution, is it blocked or not?
     *  - What could you change to address the above effect?
     *  - How could you achieve something similar to what we did with Parallel.For?
     *  - How would you implement the parallelism limitation?
     *
     * Hint:
     *  - You can use `PrintCurrentThread` or other Helpers to print i.ex. the current managed thread ID
     */
    private Task[] ImplementHere()
    {
        // TODO
        return new Task[4] {
            Task.CompletedTask,
            Task.CompletedTask,
            Task.CompletedTask,
            Task.CompletedTask
         };
    }

    [Test]
    public Task Run()
    {
        return Task.WhenAll(ImplementHere()).TaskState();
    }
}