using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace IqOptionApiDotNet.Core
{
    using EventTask = Tuple<SendOrPostCallback, object>;
    using EventQueue = ConcurrentQueue<Tuple<SendOrPostCallback, object>>;
    
    /// <summary>
    /// A Helper class to run Asynchronous functions from synchronous ones
    /// </summary>
    public static class AsyncHelper
    {
        /// <summary>
        /// A class to bridge synchronous asynchronous methods
        /// </summary>
        public class AsyncBridge : IDisposable
        {
            private readonly ExclusiveSynchronizationContext _currentContext;
            private readonly SynchronizationContext _oldContext;
            private int _taskCount;
            private bool _hasAsyncTasks;

            /// <summary>
            /// Constructs the AsyncBridge by capturing the current
            /// SynchronizationContext and replacing it with a new
            /// ExclusiveSynchronizationContext.
            /// </summary>
            internal AsyncBridge()
            {
                _oldContext = SynchronizationContext.Current;
                _currentContext = new ExclusiveSynchronizationContext(_oldContext);
                SynchronizationContext.SetSynchronizationContext(_currentContext);
            }

            /// <summary>
            /// Execute's an async task with a void return type
            /// from a synchronous context
            /// </summary>
            /// <param name="task">Task to execute</param>
            /// <param name="callback">Optional callback</param>
            public void Run(Task task, Action<Task> callback = null)
            {
                _hasAsyncTasks = true;
                _currentContext.Post(
                    async _ =>
                    {
                        try
                        {
                            Increment();
                            await task.ConfigureAwait(true);
                            callback?.Invoke(task);
                        }
                        catch (Exception e)
                        {
                            _currentContext.InnerException = e;
                        }
                        finally
                        {
                            Decrement();
                        }
                    },
                    null);
            }

            /// <summary>
            /// Execute's an async task with a T return type
            /// from a synchronous context
            /// </summary>
            /// <typeparam name="T">The type of the task</typeparam>
            /// <param name="task">Task to execute</param>
            /// <param name="callback">Optional callback</param>
            public void Run<T>(Task<T> task, Action<Task<T>> callback = null)
            {
                if (null != callback)
                {
                    Run((Task)task, (finishedTask) => callback((Task<T>)finishedTask));
                }
                else
                {
                    Run((Task)task);
                }
            }

            /// <summary>
            /// Execute's an async task with a T return type
            /// from a synchronous context
            /// </summary>
            /// <typeparam name="T">The type of the task</typeparam>
            /// <param name="task">Task to execute</param>
            /// <param name="callback">
            /// The callback function that uses the result of the task
            /// </param>
            public void Run<T>(Task<T> task, Action<T> callback)
            {
                Run(task, (t) => callback(t.Result));
            }

            private void Increment()
            {
                Interlocked.Increment(ref _taskCount);
            }

            private void Decrement()
            {
                Interlocked.Decrement(ref _taskCount);
                if (_taskCount == 0)
                {
                    _currentContext.EndMessageLoop();
                }
            }

            /// <summary>
            /// Disposes the object
            /// </summary>
            public void Dispose()
            {
                try
                {
                    if (_hasAsyncTasks)
                    {
                        _currentContext.BeginMessageLoop();
                    }
                }
                finally
                {
                    SynchronizationContext.SetSynchronizationContext(_oldContext);
                }
            }
        }

        /// <summary>
        /// Creates a new AsyncBridge. This should always be used in
        /// conjunction with the using statement, to ensure it is disposed
        /// </summary>
        public static AsyncBridge Wait => new AsyncBridge();

        /// <summary>
        /// Runs a task with the "Fire and Forget" pattern using Task.Run,
        /// and unwraps and handles exceptions
        /// </summary>
        /// <param name="task">A function that returns the task to run</param>
        /// <param name="handle">Error handling action, null by default</param>
        public static void FireAndForget(
            Func<Task> task,
            Action<Exception> handle = null)
        {
            Task.Run(() =>
            {
                ((Func<Task>)(async () =>
                {
                    try
                    {
                        await task().ConfigureAwait(true);
                    }
                    catch (Exception e)
                    {
                        handle?.Invoke(e);
                    }
                }))();
            });
        }

        private class ExclusiveSynchronizationContext : SynchronizationContext
        {
            private readonly AutoResetEvent _workItemsWaiting = new AutoResetEvent(false);
            private bool _done;
            private readonly EventQueue _items;

            public Exception InnerException { private get; set; }

            public ExclusiveSynchronizationContext(SynchronizationContext old)
            {
                var oldEx = old as ExclusiveSynchronizationContext;
                _items = null != oldEx ? oldEx._items : new EventQueue();
            }

            public override void Send(SendOrPostCallback d, object state)
            {
                throw new NotSupportedException("We cannot send to our same thread");
            }

            public override void Post(SendOrPostCallback d, object state)
            {
                _items.Enqueue(Tuple.Create(d, state));
                _workItemsWaiting.Set();
            }

            public void EndMessageLoop()
            {
                Post(_ => _done = true, null);
            }

            public void BeginMessageLoop()
            {
                while (!_done)
                {
                    EventTask task;

                    if (!_items.TryDequeue(out task))
                    {
                        task = null;
                    }

                    if (task != null)
                    {
                        task.Item1(task.Item2);
                        if (InnerException != null)
                        {
                            throw new AggregateException(
                                "AsyncBridge.Run method threw an exception.",
                                InnerException);
                        }
                    }
                    else
                    {
                        _workItemsWaiting.WaitOne();
                    }
                }
            }

            public override SynchronizationContext CreateCopy()
            {
                return this;
            }
        }
    }
}