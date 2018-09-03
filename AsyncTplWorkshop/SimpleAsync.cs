using System.Threading.Tasks;
using NUnit.Framework;

[TestFixture]
public class SimpleAsync
{
    /*
     * Exercise:
     *  Before you get started look at the current compiled code with a reflector, i.ex. dotPeek
     *  https://www.jetbrains.com/decompiler/
     *  Use `Task.Delay` and print the current thread before and after Task.Delay
     *  Use the async / await keywords
     *  Look at the code again with the reflector, what changed and why? Discuss with your peers
     *
     * Bonus:
     *  - Implement the same code behavior including the console statements with traditional TPL continuation
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