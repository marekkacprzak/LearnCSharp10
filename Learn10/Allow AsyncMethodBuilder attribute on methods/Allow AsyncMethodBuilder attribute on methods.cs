using System.Runtime.CompilerServices;
using static System.Threading.Thread;

namespace Learn10.Allow_AsyncMethodBuilder_attribute_on_methods;

public class Allow_AsyncMethodBuilder_attribute_on_methods
{
    public static async TaskLike Test()
    {
        await Task.Yield();
        await default(TaskLike);

        var testThreadId = CurrentThread.ManagedThreadId;
        await Sample();

        async Task Sample()
        {
            Console.WriteLine($"Current thread and test thread equal: {CurrentThread.ManagedThreadId != testThreadId}");

            await default(HopToThreadPoolAwaitable);
            Console.WriteLine($"Current thread and test thread equal: {CurrentThread.ManagedThreadId != testThreadId}");
        }
    }
}

[AsyncMethodBuilder(typeof(TaskLikeMethodBuilder))]
public struct TaskLike
{
    public TaskLikeAwaiter GetAwaiter() => default(TaskLikeAwaiter);
}

public struct TaskLikeAwaiter : INotifyCompletion
{
    public void GetResult() { Console.WriteLine("Get result");}

    public bool IsCompleted => true;

    public void OnCompleted(Action continuation) { }
}
public struct HopToThreadPoolAwaitable : INotifyCompletion
{
    public HopToThreadPoolAwaitable GetAwaiter() => this;
    public bool IsCompleted => false;

    public void OnCompleted(Action continuation) => Task.Run(continuation);
    public void GetResult() { }
}
