using System;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

[TestFixture]
public class TaskFactoryStartNew
{
    /*
     * Exercise:
     *  Use `Task.Factory.StartNew` in combination with `CpuBound.Compute` to sort one array of size 10..15 in parallel
     *  Make Task.Factory.StartNew behave like Task.Run
     *  Discuss with your peers what the difference is between Task.Run and Task.Factory.StartNew
     *
     * Bonus:
     *  - What happens to the thread of execution, is it blocked or not?
     *  - What could you change to address the above effect?
     *  - How could you achieve something similar to what we did with Parallel.For?
     *  - How would you implement the parallelism limitation?
     *  - Create a new TestFixture with parent and child tasks, use `DenyChildAttach` and `Task.Run` 
     *    as well as `Task.Factory.StartNew` to observe how it influences the runtime behavior
     *
     * Hint:
     *  - You can use `PrintCurrentThread` or other Helpers to print i.ex. the current managed thread ID
     *  - You might need to use dotPeek, .NET Reflector or references sources
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