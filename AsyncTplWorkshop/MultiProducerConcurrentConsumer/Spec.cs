namespace AsyncTplWorkshop.MultiProducerConcurrentConsumer
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using NUnit.Framework;

    /*
     * Bonus Exercise:
        The multi producer concurrent consumer is a reactive collection with slots, batchSize, pushInterval and maximum concurrency. The guarantees are the following:
       - It is fully asynchronous
       - Pushing to it is thread safe
       - It respects the batchSize and automatically fans out if there is more to complete for a given slot when there is still concurrency left
       - It completes messages when they arrive slower under the predefined push interval
       - Only ever one thread is executing the pump logic but the completions are faned out
       - The pump callback will only receive data for a given slot
       - No contention between slots
       - Lock-free
       - Allocates the necessary collections up front for the maxed out scenario. The only allocations you pay during runtime is a Tuple and the async statemachine
       - Has FIFO semantics instead of LIFO

        Implement the above requirements, below is a bunch of tests that help you drive the implementation

        See also Overview.png
     */
    [TestFixture]
    public class When_using_multiproducerconcurrentcompletion
    {
        [Test]
        public async Task Pushing_for_slots_before_start_works_when_batch_size_is_reached()
        {
            var receivedItems = new ConcurrentQueue<List<int>>[4]
            {
                new ConcurrentQueue<List<int>>(),
                new ConcurrentQueue<List<int>>(),
                new ConcurrentQueue<List<int>>(),
                new ConcurrentQueue<List<int>>(),
            };

            var countDownEvent = new CountdownEvent(16);

            // choose insanely high push interval
            var completion = new MultiProducerConcurrentCompletion<int>(batchSize: 100, pushInterval: TimeSpan.FromDays(1), maxConcurrency: 4, numberOfSlots: 4);

            var numberOfItems = await PushConcurrentlyTwoThousandItemsInPackagesOfFiveHundredIntoFourSlots(completion);

            completion.Start((items, slot, state, token) =>
            {
                receivedItems[slot].Enqueue(new List<int>(items)); // take a copy
                if (!countDownEvent.IsSet)
                {
                    countDownEvent.Signal();
                }
                return Task.FromResult(0);
            });

            await Task.Run(() => countDownEvent.Wait(TimeSpan.FromSeconds(5)));

            var snapShotOfElementsBeforeComplete = Flatten(receivedItems).Count();

            await completion.Complete();

            Assert.AreEqual(1600, snapShotOfElementsBeforeComplete);
            Assert.AreEqual(TriangularNumber(numberOfItems), Flatten(receivedItems).Sum(i => i));
        }

        [Test]
        public async Task Pushing_for_slots_after_start_works_when_batch_size_is_reached()
        {
            var receivedItems = new ConcurrentQueue<List<int>>[4]
            {
                new ConcurrentQueue<List<int>>(),
                new ConcurrentQueue<List<int>>(),
                new ConcurrentQueue<List<int>>(),
                new ConcurrentQueue<List<int>>(),
            };

            var countDownEvent = new CountdownEvent(16);

            // choose insanely high push interval
            var completion = new MultiProducerConcurrentCompletion<int>(batchSize: 100, pushInterval: TimeSpan.FromDays(1), maxConcurrency: 4, numberOfSlots: 4);

            completion.Start((items, slot, state, token) =>
            {
                receivedItems[slot].Enqueue(new List<int>(items)); // take a copy
                if (!countDownEvent.IsSet)
                {
                    countDownEvent.Signal();
                }
                return Task.FromResult(0);
            });

            var numberOfItems = await PushConcurrentlyTwoThousandItemsInPackagesOfFiveHundredIntoFourSlots(completion);

            // we wait for 16 counts and then complete midway
            await Task.Run(() => countDownEvent.Wait(TimeSpan.FromSeconds(5)));

            await completion.Complete();

            Assert.AreEqual(TriangularNumber(numberOfItems), Flatten(receivedItems).Sum(i => i));
        }

        [Test]
        public async Task Pushing_for_slots_before_start_works_when_pushInterval_reached()
        {
            var receivedItems = new ConcurrentQueue<List<int>>[4]
            {
                new ConcurrentQueue<List<int>>(),
                new ConcurrentQueue<List<int>>(),
                new ConcurrentQueue<List<int>>(),
                new ConcurrentQueue<List<int>>(),
            };

            var countDownEvent = new CountdownEvent(4);

            // choose insanely high batchSize
            var completion = new MultiProducerConcurrentCompletion<int>(batchSize: 10000, pushInterval: TimeSpan.FromMilliseconds(1), maxConcurrency: 4, numberOfSlots: 4);

            var numberOfItems = await PushConcurrentlyTwoThousandItemsInPackagesOfFiveHundredIntoFourSlots(completion);

            completion.Start((items, slot, state, token) =>
            {
                receivedItems[slot].Enqueue(new List<int>(items)); // take a copy
                if (!countDownEvent.IsSet)
                {
                    countDownEvent.Signal();
                }
                return Task.FromResult(0);
            });

            await Task.Run(() => countDownEvent.Wait(TimeSpan.FromSeconds(5)));

            var sumOfAllElementsSeenSoFar = Flatten(receivedItems).Sum(i => i);

            await completion.Complete();

            Assert.AreEqual(TriangularNumber(numberOfItems), sumOfAllElementsSeenSoFar);
            Assert.AreEqual(TriangularNumber(numberOfItems), Flatten(receivedItems).Sum(i => i), "Dispatcher complete brought more items than expected");
        }

        [Test]
        public async Task Pushing_for_slots_after_start_works_when_pushInterval_reached()
        {
            var receivedItems = new ConcurrentQueue<List<int>>[4]
            {
                new ConcurrentQueue<List<int>>(),
                new ConcurrentQueue<List<int>>(),
                new ConcurrentQueue<List<int>>(),
                new ConcurrentQueue<List<int>>(),
            };

            var countDownEvent = new CountdownEvent(4);

            // choose insanely high batchSize to force push interval picking up all the content
            var completion = new MultiProducerConcurrentCompletion<int>(batchSize: 10000, pushInterval: TimeSpan.FromMilliseconds(1), maxConcurrency: 4, numberOfSlots: 4);

            completion.Start((items, slot, state, token) =>
            {
                receivedItems[slot].Enqueue(new List<int>(items)); // take a copy
                if (!countDownEvent.IsSet)
                {
                    countDownEvent.Signal();
                }
                return Task.FromResult(0);
            });

            var numberOfItems = await PushConcurrentlyTwoThousandItemsInPackagesOfFiveHundredIntoFourSlots(completion);

            await Task.Run(() => countDownEvent.Wait(TimeSpan.FromSeconds(5)));

            var sumOfAllElementsSeenSoFar = Flatten(receivedItems).Sum(i => i);

            await completion.Complete();

            Assert.AreEqual(TriangularNumber(numberOfItems), sumOfAllElementsSeenSoFar);
            Assert.AreEqual(TriangularNumber(numberOfItems), Flatten(receivedItems).Sum(i => i), "Dispatcher complete brought more items than expected");
        }

        [Test]
        public async Task Pushing_and_complete_with_no_drain_without_start_empties_slots()
        {
            var pushedItems = new ConcurrentQueue<List<int>>[4]
            {
                new ConcurrentQueue<List<int>>(),
                new ConcurrentQueue<List<int>>(),
                new ConcurrentQueue<List<int>>(),
                new ConcurrentQueue<List<int>>(),
            };

            // choose insanely high batchSize to force push interval picking up all the content
            var completion = new MultiProducerConcurrentCompletion<int>(batchSize: 100, pushInterval: TimeSpan.FromMilliseconds(1), maxConcurrency: 4, numberOfSlots: 4);

            await PushConcurrentlyTwoThousandItemsInPackagesOfFiveHundredIntoFourSlots(completion);

            await completion.Complete(drain: false);

            var countDownEvent = new CountdownEvent(1);
            completion.Start((items, slot, state, token) =>
            {
                pushedItems[slot].Enqueue(new List<int>(items)); // take a copy
                countDownEvent.Signal();
                return Task.FromResult(0);
            });

            completion.Push(1, slotNumber: 1);

            await Task.Run(() => countDownEvent.Wait(TimeSpan.FromSeconds(5)));

            await completion.Complete();

            Assert.AreEqual(1, Flatten(pushedItems).Sum(i => i));
        }

        [Test]
        public async Task Complete_works_even_when_push_interval_and_batch_size_not_reached()
        {
            var receivedItems = new ConcurrentQueue<List<int>>[4]
            {
                new ConcurrentQueue<List<int>>(),
                new ConcurrentQueue<List<int>>(),
                new ConcurrentQueue<List<int>>(),
                new ConcurrentQueue<List<int>>(),
            };

            // choose insanely high batchSize and pushInterval to force the loop hanging
            var completion = new MultiProducerConcurrentCompletion<int>(batchSize: 10000, pushInterval: TimeSpan.FromDays(1), maxConcurrency: 4, numberOfSlots: 4);

            completion.Start((items, slot, state, token) =>
            {
                receivedItems[slot].Enqueue(new List<int>(items)); // take a copy
                return Task.FromResult(0);
            });

            var numberOfItems = await PushConcurrentlyTwoThousandItemsInPackagesOfFiveHundredIntoFourSlots(completion);

            await completion.Complete();

            var sumOfAllElementsSeenSoFar = Flatten(receivedItems).Sum(i => i);

            Assert.AreEqual(TriangularNumber(numberOfItems), sumOfAllElementsSeenSoFar);
            Assert.AreEqual(TriangularNumber(numberOfItems), Flatten(receivedItems).Sum(i => i), "Dispatcher complete brought more items than expected");
        }

        static async Task<int> PushConcurrentlyTwoThousandItemsInPackagesOfFiveHundredIntoFourSlots(MultiProducerConcurrentCompletion<int> completion)
        {
            var t1 = Task.Run(() => Parallel.For(1, 500, i =>
            {
                completion.Push(slotNumber: 0, item: i);
            }));

            var t2 = Task.Run(() => Parallel.For(500, 1000, i =>
            {
                completion.Push(slotNumber: 1, item: i);
            }));

            var t3 = Task.Run(() => Parallel.For(1000, 1500, i =>
            {
                completion.Push(slotNumber: 2, item: i);
            }));

            await Task.WhenAll(t1, t2, t3);

            var numberOfItems = 2000;
            for (var i = 1500; i < numberOfItems + 1; i++)
            {
                completion.Push(slotNumber: 3, item: i);
            }
            return numberOfItems;
        }

        int TriangularNumber(int numberOfItems)
        {
            return numberOfItems * (numberOfItems + 1) / 2;
        }

        IEnumerable<int> Flatten(ConcurrentQueue<List<int>>[] captured)
        {
            var allCaptured = new List<int>();
            foreach (var queue in captured)
            {
                foreach (var list in queue.ToArray())
                {
                    allCaptured.AddRange(list);
                }
            }
            return allCaptured.OrderBy(i => i);
        }
    }
}