using System.Threading.Tasks;
using NUnit.Framework;

[TestFixture]
public class ParallelInvoke
{
    /*
     * Exercise:
     *  Use `Parallel.Invoke` in combination with `CpuBound.Compute` to sort multiple arrays of size 10..15 in parallel
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
        Parallel.Invoke(new ParallelOptions{ MaxDegreeOfParallelism = 4}, 
            () => CpuBound.Compute(10), 
            () => CpuBound.Compute(11),
            () => CpuBound.Compute(12),
            () => CpuBound.Compute(13),
            () => CpuBound.Compute(14),
            () => CpuBound.Compute(15)
        );
        return Task.CompletedTask;
    }

    [Test]
    public Task Run()
    {
        return ImplementHere().TaskState();
    }
}