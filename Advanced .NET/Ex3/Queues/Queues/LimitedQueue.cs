using System;
using System.Collections.Generic;
using System.Threading;

namespace Queues
{
    class LimitedQueue<T>
    {
        private readonly Queue<T> _queue;
        private readonly Semaphore _writersSemaphore, _readersSemaphore;

        public LimitedQueue(int maxQueueSize)
        {
            if (maxQueueSize < 1)
            {
                Console.WriteLine("Max queue size can't be lower than 1");
               throw new ArgumentOutOfRangeException();
            }

            _writersSemaphore = new Semaphore(maxQueueSize, maxQueueSize);
            _readersSemaphore = new Semaphore(0, maxQueueSize);
            _queue = new Queue<T>();
        }

        public void Enqueue(T item)
        {
            _writersSemaphore.WaitOne();
            lock (_queue)
            {
                _queue.Enqueue(item);
            }
            _readersSemaphore.Release();
        }

        public T Dequeue()
        {
            _readersSemaphore.WaitOne();
            T item;

            lock (_queue)
            {
                item = _queue.Dequeue();
            }
            _writersSemaphore.Release();
            return item;
        }
    }
}
