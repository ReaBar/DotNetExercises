using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomAwaiter
{
    class IntAwaitable
    {
        private readonly int _millisecondsDelay = 0;

        public IntAwaitable(int millisecondsDelay)
        {
            _millisecondsDelay = millisecondsDelay;
        }

        public CustomIntAwaiter GetAwaiter()
        {
            Thread.Sleep(_millisecondsDelay);
            return new CustomIntAwaiter();
        }
    }
}
