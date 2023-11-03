using System.Runtime.CompilerServices;

namespace Learn10.Allow_AsyncMethodBuilder_attribute_on_methods;

//https://github.com/marekkacprzak/EduAsync
public sealed class TaskLikeMethodBuilder
{
    public TaskLikeMethodBuilder()
        => Console.WriteLine(".ctor");

    public static TaskLikeMethodBuilder Create()
    {
        Console.WriteLine("create builder");
        return new TaskLikeMethodBuilder();
    }

    public void SetResult() => Console.WriteLine("SetResult");

    public void Start<TStateMachine>(ref TStateMachine stateMachine)
        where TStateMachine : IAsyncStateMachine
    {
        Console.WriteLine("Start");
        stateMachine.MoveNext();
    }

    public TaskLike Task => default(TaskLike);

    // AwaitOnCompleted, AwaitUnsafeOnCompleted, SetException 
    // and SetStateMachine are empty
    public void AwaitOnCompleted<TAwaiter, TStateMachine>(
        ref TAwaiter awaiter, ref TStateMachine stateMachine)
        where TAwaiter : INotifyCompletion
        where TStateMachine : IAsyncStateMachine
    { }

    public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(
        ref TAwaiter awaiter, ref TStateMachine stateMachine)
        where TAwaiter : ICriticalNotifyCompletion
        where TStateMachine : IAsyncStateMachine
    { }

    public void SetException(Exception e) { }

    public void SetStateMachine(IAsyncStateMachine stateMachine) { }
}