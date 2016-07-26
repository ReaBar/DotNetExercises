using System.Collections.Generic;

namespace PrimesCalculator
{
    class PrimeNumbers
    {
        public List<string> CalcPrimes(int subtracted, int subtrahend)
        {
            List<string> primesList = new List<string>();;

            for (int i = subtracted; i <= subtrahend; i++)
            {
                bool isPrime = IsNumPrime(i);
                if (isPrime)
                {
                    primesList.Add(i.ToString());
                }
            }

            return primesList;
        }

        private bool IsNumPrime(int num)
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
