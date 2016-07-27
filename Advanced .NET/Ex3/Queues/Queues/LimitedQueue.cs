using System;
using System.Collections.Generic;
using System.Threading;

namespace Queues
{
    class LimitedQueue<T>
    {
        private readonly Queue<T> _queue;
        private readonly SemaphoreSlim _semaphore;
        private int _maxQueueSize;
        private readonly ReaderWriterLockSlim _rwLockSlim;

        public LimitedQueue(int maxQueueSize)
        {
            if (maxQueueSize < 1)
            {
                throw new ArgumentOutOfRangeException($"Max queue size can't be lower than 1");
            }

            _rwLockSlim = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
            _maxQueueSize = maxQueueSize;
            _semaphore = new SemaphoreSlim(maxQueueSize);
            _queue = new Queue<T>();
        }

        public void Enqueue(T item)
        {
            _semaphore.Wait();
            if (!_rwLockSlim.IsWriteLockHeld)
            {
                _rwLockSlim.EnterWriteLock();
            }
            _queue.Enqueue(item);
            Console.WriteLine($"queue count is {_queue.Count}");
            _rwLockSlim.ExitWriteLock();
            if (_rwLockSlim.IsReadLockHeld)
            {
                _rwLockSlim.ExitReadLock();
            }
        }

        public T Dequeue()
        {
            T item = default(T);
            if (_queue.Count == 0)
            {
                _rwLockSlim.EnterWriteLock();
            }

            if (!_rwLockSlim.IsWriteLockHeld)
            {
                item = _queue.Dequeue();
                Console.WriteLine($"queue count is {_queue.Count}");
            }
            _semaphore.Release();
            return item;
        }
    }
}
