using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace CustomAwaiter
{
    class CustomIntAwaiter : INotifyCompletion
    {
        private Action _continuation;

        private readonly ManualResetEventSlim _siganl = new ManualResetEventSlim();

        public void OnCompleted(Action continuation)
        {
            _continuation = continuation;
        }

        public bool IsCompleted { get; private set; }

        internal void SetCompleted()
        {
            if (IsCompleted)
            {
                return;
            }

            IsCompleted = true;
            _siganl.Set();
            _continuation?.Invoke();
        }

        public void GetResult()
        {
            if (IsCompleted)
            {
                return;
            }

            _siganl.Wait();
        }
    }
}
