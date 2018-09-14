using System;
using System.Threading;
using System.Threading.Tasks;

class Simulator
{
    public event EventHandler Completed = delegate { };
    public event EventHandler Aborted = delegate { };
    public event EventHandler<Exception> Failed = delegate { };

    public void Start(int fireAfterMilliseconds = 500, bool abort = false, Exception failed = null)
    {
        Task.Delay(fireAfterMilliseconds).ContinueWith(t =>
        {
            if (abort)
            {
                OnAbort();
            }
            else if (failed != null)
            {
                OnFailed(failed);
            }
            else
            {
                OnCompleted();
            }
        });
    }

    void OnFailed(Exception failed)
    {
        Console.WriteLine($"Failed on {Thread.CurrentThread.ManagedThreadId}");
        this.Failed(this, failed);
    }

    void OnCompleted()
    {
        Console.WriteLine($"Completed on {Thread.CurrentThread.ManagedThreadId}");
        this.Completed(this, EventArgs.Empty);
    }

    void OnAbort()
    {
        Console.WriteLine($"Abort on {Thread.CurrentThread.ManagedThreadId}");
        this.Aborted(this, EventArgs.Empty);
    }
}