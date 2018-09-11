using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

[TestFixture]
public class FireAndForgot
{
    /*
     * Exercise:
     *  Kick of a task for example with `Task.Delay` without awaiting it
     *  What do you have to do to satisfy the compiler?
     *  Play around with multiple possibilities to satisfy the compiler
     *
     * Hint:
     *  - Conditional continuations are not necessary
     *  - Compiler suppression, extension method or change the return type of the method
     *
     */
    private async Task ImplementHere()
    {
        // TODO
    }

    [Test]
    public Task Run()
    {
        return ImplementHere().TaskState();
    }
}