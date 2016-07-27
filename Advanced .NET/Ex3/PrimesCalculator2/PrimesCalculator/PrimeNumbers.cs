using System.Collections.Generic;
using System.Threading;

namespace PrimesCalculator
{
    class PrimeNumbers
    {
        public List<string> CalcPrimes(uint subtracted, uint subtrahend, CancellationToken cancellationToken)
        {
            List<string> primesList = new List<string>();;

            for (uint i = subtracted; i <= subtrahend; i++)
            {
                bool isPrime = IsNumPrime(i);

                if (cancellationToken.IsCancellationRequested)
                {
                    return null;
                }

                if (isPrime)
                {
                    primesList.Add(i.ToString());
                }
            }

            return primesList;
        }

        private bool IsNumPrime(uint num)
        {
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
