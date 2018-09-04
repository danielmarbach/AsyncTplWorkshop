using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTplWorkshop.MultiProducerConcurrentConsumer
{
    /// <summary>
    /// This is essentially a reactive collection which allows to push elements to multiple slots. When either the batchSize is
    /// reached or the pushInterval
    /// then the data if available is pushed to the callback which is passed into the start method. The callback is invoked per
    /// slot up to the specified maximum concurrency per slot.
    /// The implementation makes a number of trade-offs by preallocating the item lists for the specified maximum concurrency
    /// and available slots.
    /// </summary>
    /// <typeparam name="TItem">The item that is managed by the dispatcher.</typeparam>
    class MultiProducerConcurrentCompletion<TItem>
    {
        private int maxConcurrency;
        private TimeSpan pushInterval;
        private int batchSize;
        private int numberOfSlots;

        public MultiProducerConcurrentCompletion(int batchSize, TimeSpan pushInterval, int maxConcurrency,
            int numberOfSlots)
        {
            this.maxConcurrency = maxConcurrency;
            this.pushInterval = pushInterval;
            this.batchSize = batchSize;
            this.numberOfSlots = numberOfSlots;
        }

        /// <summary>
        /// Specifies a pump function. As soon as items are available pumping begins within the specified constraints
        /// </summary>
        /// <remarks>This member is not thread safe.</remarks>
        public void Start(Func<IEnumerable<TItem>, int, object, CancellationToken, Task> pump)
        {
            Start(pump, null);
        }

        /// <summary>
        /// Specifies a pump function. As soon as items are available pumping begins within the specified constraints
        /// </summary>
        /// <remarks>This member is not thread safe.</remarks>
        public void Start(Func<IEnumerable<TItem>, int, object, CancellationToken, Task> pump, object state)
        {

        }

        /// <summary>
        /// Pushes an item for the specified slot number. Pushing is allowed even when the dispatcher is not started.
        /// </summary>
        /// <param name="item">The item to be pushed.</param>
        /// <param name="slotNumber">The slot number which is zero based.</param>
        /// <remarks>This member is thread safe.</remarks>
        public void Push(TItem item, int slotNumber)
        {
        }

        /// <summary>
        /// Completes the dispatching asynchronously. If necessary remaining items will be pushed asynchronously on the thread
        /// entering this method.
        /// It is possible to start the dispatching again but the pump function as well as the required state has to be passed in
        /// again.
        /// </summary>
        /// <param name="drain">
        /// Indicates whether remaing items in the slots should be drained and pushed to the listener.
        /// Specifying <c>false</c> will empty the slots without pushing.
        /// </param>
        /// <remarks>This member is not thread safe.</remarks>
        public Task Complete(bool drain = true)
        {
            return Task.CompletedTask;
        }
    }
}