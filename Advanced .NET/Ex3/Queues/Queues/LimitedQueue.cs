using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{
    class LimitedQueue
    {
        Queue<Task> _queue;
        SemaphoreSlim _semaphore;

        public LimitedQueue(int maxQueueSize)
        {
            _semaphore = new SemaphoreSlim(maxQueueSize);
            _queue = new Queue<Task>();

        }

    }
}
