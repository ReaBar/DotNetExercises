
using System.Threading;

namespace PrimesCalculator
{
    class PrimeNumbers
    {
        public int CountPrimesAsync(int subtracted, int subtrahend, CancellationToken cancellationToken)
        {
            var primesCounter = 0;

            for (int i = subtracted; i <= subtrahend; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return primesCounter;
                }

                if (IsNumPrime(i))
                {
                    primesCounter++;
                }
            }              
            return primesCounter;
        }

        private bool IsNumPrime(int num)
        {
            if (num == 1 || num == 0)
            {
                return false;
            }

            if (num == 2 || num == 3)
            {
                return true;
            }

            if ((num % 2 == 0) || (num % 3 == 0))
            {
                return false;
            }

            for (int i = 5; i * i <= num; i += 6)
            {
                if (num % i == 0 || num % (i + 2) == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
