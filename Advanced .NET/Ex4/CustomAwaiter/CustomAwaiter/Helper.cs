using System;
using System.Diagnostics;

namespace CustomAwaiter
{
    class Helper
    {

        public async void IntDelay(int millisecondsDelay)
        {
            var awaitable = new IntAwaitable();
            Console.WriteLine("milliseconds delay started");
            await awaitable.Wait(millisecondsDelay);
            Console.WriteLine("milliseconds delay Finished");
        }

        public async void ProcessAwaiter(Process process)
        {
            var awaitable = new ProcessAwaitable();
            Console.WriteLine("process termination started");
            await awaitable.Wait(process);
            Console.WriteLine("process termination Finished");
        }
    }
}
