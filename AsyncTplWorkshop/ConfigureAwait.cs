using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

[TestFixture]
public class ConfigureAwait
{
    /*
     * Exercise:
     *  Implement a Method that uses `Task.Delay` twice, first with ConfigureAwait(false), second without
     *  Call that method once without `ConfigureAwait(false)` and the second time with `ConfigureAwait(false)`
     *  What behavior do you observe?
     *  What is influenced by `ConfigureAwait(false)`
     *
     * Bonus:
     *  - Create a WPF app and do the same in the code behind file what is the difference and what behavior do you observe
     *  - Would you recommend to use ConfigureAwait(false) in such an app and if yes under what circumstances?
     *  - Can you dig the compiler generated code that deals with `ConfigureAwait`? What does it do in the TPL world?
     *
     * Hint:
     *  - You can use `PrintCurrentThread` or other Helpers to print i.ex. the current managed thread ID
     *  - You can use `PrintCurrentContext` to print out the current context with a message
     */
    private Task ImplementHere()
    {
        // TODO
        return Task.CompletedTask;
    }

    [Test]
    public Task Run()
    {
        return this.WrapInContext(ImplementHere)
            .TaskState();
    }
}