# AsyncTplWorkshop
Workshop Material for the async/tpl

## Exercise order

1. ParallelInvoke
1. ParallelFor
1. ParallelForEach
1. TaskRun
1. TaskFactoryStartNew
1. SimpleAsync
1. FireAndForgot
1. AsyncVoid
1. ConfigureAwait
1. AsyncAllTheWay
1. SequentialExecution
1. ConcurrentExecutionAll
1. ConcurrentExecutionOne
1. ParallelExecution
1. CancelTask
1. CancelTaskOperation
1. ConcurrencyLimit
1. YourPump
1. TaskCompletionSource
1. MultiProducerConcurrentConsumer

## Links & Material

- [Solutions](https://github.com/danielmarbach/Await.HeadExplosion/Presentation) requires .NET Core 2.1 and higher, run with `dotnet run -f netcoreapp2.1`
- [MultiProducerConcurrentConsumer](https://github.com/Particular/NServiceBus.AzureServiceBus/blob/develop/src/Transport/Receiving/MultiProducerConcurrentCompletion.cs)
- [Rearchitect your code towards async / await](https://vimeo.com/172111826)
- [Six Essential Tips for Async](http://channel9.msdn.com/Series/Three-Essential-Tips-for-Async)
- [Asynchronous Programming with Async and Await](https://msdn.microsoft.com/en-us/library/hh191443.aspx)
- [Async/Await - Best Practices in Asynchronous Programming](https://msdn.microsoft.com/en-us/magazine/jj991977.aspx)
- [Async/Await FAQ](http://blogs.msdn.com/b/pfxteam/archive/2012/04/12/async-await-faq.aspx)
- [Should I expose synchronous wrappers for asynchronous methods?](http://blogs.msdn.com/b/pfxteam/archive/2012/04/13/10293638.aspx)
- [Should I expose asynchronous wrappers for synchronous methods?](http://blogs.msdn.com/b/pfxteam/archive/2012/03/24/10287244.aspx)
- [Task Parallel Library](https://msdn.microsoft.com/en-us/library/dd460717.aspx)
- [`Task.Factory.StartNew` vs `Task.Run`](http://blogs.msdn.com/b/pfxteam/archive/2011/10/24/10229468.aspx)
- [ConfigureAwait Rosly Analyzer](https://github.com/Particular/Particular.CodeRules/tree/master/src/Particular.CodeRules/ConfigureAwait)
- [Async Fixer extension](https://visualstudiogallery.msdn.microsoft.com/03448836-db42-46b3-a5c7-5fc5d36a8308)