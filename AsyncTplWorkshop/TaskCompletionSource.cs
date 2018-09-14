﻿using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

[TestFixture]
public class TaskCompletionSource
{
    /*
     * Exercise:
     *  Use the Simulator class and a TaskCompletionSource to create a task that is completed when the simulator
     *  fires the `Completed` event, cancelled when the `Aborted` event is fired and failed when the `Failed`
     *  event is fired.
     *  When the failed event is raised the exception needs to be passed to the task
     *  What is the difference between Set... and TrySet.. methods, when would you use what?
     *  Can TaskCompletionSources be reused?
     *
     * Bonus:
     *  - Implement cancellation token support to cancel the task when non of the events are fired after some time
     *
     * Hint:
     *  - The semaphore has to be acquired and released
     */
    private Task ImplementHere()
    {
        return Task.CompletedTask;
    }

    [Test]
    public Task Run()
    {
        return ImplementHere().TaskState();
    }
}