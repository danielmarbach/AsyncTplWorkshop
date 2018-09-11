using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

[TestFixture]
public class AsyncAllTheWay
{
    /*
     * Exercise:
     *  Use `Method` in the implementation
     *  What happens? Can you explain the behavior to your peers?
     *  What are the consequences of this behavior for the code you write and where it is executed?
     *
     * Bonus:
     *  - There are three ways to solve this problem? Can you come up with them?
     *  - What is the difference between .Wait() or .GetAwaiter().GetResult(), try it out by throwing an exception
     *
     * Hint:
     *  - You can use `PrintCurrentThread` or other Helpers to print i.ex. the current managed thread ID
     */
    private Task ImplementHere()
    {
        // TODO
        return Task.CompletedTask;
    }

    void Method()
    {
        MethodAsync().Wait();
        // or try
        // MethodAsync().GetAwaiter().GetResult();
        // or try
        //MethodAsync().ConfigureAwait(false).GetAwaiter().GetResult();
    }

    async Task MethodAsync()
    {
        await Task.Delay(200);
    }

    [Test]
    public Task Run()
    {
        return this.WrapInContext(ImplementHere).TaskState();
    }
}