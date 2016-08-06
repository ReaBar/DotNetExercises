using System.Threading;
using System.Threading.Tasks;

namespace CustomAwaiter
{
    class IntAwaitable
    {
        private CustomIntAwaiter _awaiter;

        private IntAwaitable(CustomIntAwaiter awaiter)
        {
            _awaiter = awaiter;
        }

        public IntAwaitable Wait(int milliseconds)
        {
            var awaiter = new CustomIntAwaiter();

            Task.Run(() =>
            {
                Thread.Sleep(milliseconds);
                awaiter.SetCompleted();
            });

            return new IntAwaitable(awaiter);
        }

        public CustomIntAwaiter GetAwaiter() => _awaiter;
    }
}
