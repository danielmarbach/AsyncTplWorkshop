using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace AsyncTplWorkshop.YourPump
{
    public class PushMessages : IPushMessages
    {
        private readonly ConcurrentQueue<MessageContext> messages;
        private readonly int maxConcurrency;

        public PushMessages(ConcurrentQueue<MessageContext> messages, int maxConcurrency = 100)
        {
            this.maxConcurrency = maxConcurrency;
            this.messages = messages;
        }

        public Task Start(Func<MessageContext, Task> onMessage)
        {
            throw new NotImplementedException();
        }

        public Task Stop()
        {
            throw new NotImplementedException();
        }
    }
}