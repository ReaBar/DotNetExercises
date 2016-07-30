using System;
using System.Threading;

namespace Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int maxSize = 5;
            LimitedQueue<int> limitedQueue = new LimitedQueue<int>(maxSize);

            for (int i = 0; i < 20; i++)
            {
                var randomNum = rand.Next(0,100);
                Console.WriteLine(randomNum);
                
                if (randomNum % 2 == 0)
                {
                    var i1 = i;
                    ThreadPool.QueueUserWorkItem(x => limitedQueue.Enqueue(i1));
                }

                else
                {
                   ThreadPool.QueueUserWorkItem(x => limitedQueue.Dequeue());
                }
            }
        }
    }
}
