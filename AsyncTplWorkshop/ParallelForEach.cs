using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

[TestFixture]
public class ParallelForEach
{
    /*
     * Exercise:
     *  Use `Parallel.ForEach` in combination with `CpuBound.Compute` to sort multiple arrays of size 10..15 in parallel
     *  Use limit the parallelism to 4
     *  Discuss with your peers what happens and why
     *  Play with the parallelism constraints
     *
     * Bonus:
     *  - What happens to the thread of execution, is it blocked or not?
     *  - What could you change to address the above effect?
     *  - What sort of magic is Parallel.ForEach using behind the scenes to take the above change into account?
     *
     * Hint:
     *  - You can use `PrintCurrentThread` or other Helpers to print i.ex. the current managed thread ID
     *  - You can use `Enumerable.Range` to create numbers to pass to `CpuBound.Compute`
     */
    private Task ImplementHere()
    {
        var options = new ParallelOptions()
        {
            MaxDegreeOfParallelism = 4,
        };

        Parallel.ForEach(Enumerable.Range(5, 10), options, CpuBound.Compute);
        return Task.CompletedTask;
    }

    [Test]
    public Task Run()
    {
        return ImplementHere().TaskState();
    }
}