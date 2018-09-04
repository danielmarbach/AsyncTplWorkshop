using System;
using System.Threading.Tasks;

namespace AsyncTplWorkshop.YourPump
{
    public interface IPushMessages
    {
        Task Start(Func<MessageContext, Task> onMessage);
        Task Stop();
    }
}