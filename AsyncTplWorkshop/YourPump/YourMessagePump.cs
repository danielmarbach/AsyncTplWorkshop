using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AsyncTplWorkshop.YourPump
{
    [TestFixture]
    public class YourMessagePump
    {
        private AsyncCountdownEvent countdown;

        /*
         * Exercise:
         *  Implement a fully asynchronous message pump that fetches messages from the underlying transport
         * (here a concurrent queue) and pushed them to the `Handle` method. Augment the test infrastructure to
         *  your liking. The pump should fulfill the following requirements:
         *  - The concurrency can be limited
         *  - Start should not block
         *  - When stop is called a graceful shutdown attempt is done, meaning outstanding operations will
         *    be completed but nothing new will be scheduled
         *  - If there is nothing available the pump should not churn CPU
         *  - Exceptions in the handlers are ignored
         *
         * Bonus:
         *  - a) Implement cancellation support for handlers
         *  - b) Implement immediate retries for handlers when an exception is raised
         *  - c) Implement a timeout in stop. For example if after N seconds the handlers are not canceled exit
         *    the stop and throw a TimeoutException
         *
         * Hint:
         *  - You can use `PrintCurrentThread` or other Helpers to print i.ex. the current managed thread ID
         */
        [Test]
        public async Task Should_HandleMessages()
        {
            countdown = new AsyncCountdownEvent(3);

            var messages = new ConcurrentQueue<MessageContext>();
            messages.Enqueue(new MessageContext());
            messages.Enqueue(new MessageContext());
            messages.Enqueue(new MessageContext());

            var strategy = new PushMessages(messages, maxConcurrency: 1);

            await strategy.Start(ctx => Handle(ctx, countdown));

            await countdown.WaitAsync();

            await strategy.Stop();
        }

        public Task Handle(MessageContext message, AsyncCountdownEvent signal)
        {
            return Task.CompletedTask;
        }

        public Task HandleWithFailure(MessageContext message)
        {
            return Task.FromException(new InvalidOperationException("Boom"));
        }
    }
}