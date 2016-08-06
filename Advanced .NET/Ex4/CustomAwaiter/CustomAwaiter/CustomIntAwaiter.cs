using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace CustomAwaiter
{
    class CustomIntAwaiter : INotifyCompletion
    {
        private Action _continuation;

        public void OnCompleted(Action continuation)
        {

        }

        public bool IsCompleted { get; }


        public void GetResult()
        {
            _continuation();
        }
    }
}
