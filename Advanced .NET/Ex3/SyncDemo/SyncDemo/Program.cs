using System;
using System.Threading;
using System.Threading.Tasks;

namespace SyncDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            bool _mutexState;
            Mutex _mutex = new Mutex(true, "SyncFileMutex", out _mutexState);


        }
    }
}

