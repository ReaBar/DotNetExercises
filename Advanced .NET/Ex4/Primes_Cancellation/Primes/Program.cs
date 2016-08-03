using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Primes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> primeList = CalcPrimes(2, 30000000);
            Console.WriteLine("Number of primes found before canceled: " + primeList.Count);
        }

        public static List<long> CalcPrimes(int subtracted, int subtrahend)
        {
            List<long> primesList = new List<long>();
            Random rand=  new Random();
                      
            if (subtracted > 1 && subtrahend > 1 && subtrahend > subtracted)
            {
                Parallel.For(subtracted, subtrahend,
                    (i,state) =>
                    {
                        if (rand.Next(10000000) == 0)
                        {
                            state.Stop();
                        }

                        if ((Convert.ToInt32(i) & 1) == 0)
                        {
                            if (Convert.ToInt32(i) == 2)
                            {
                                lock (primesList)
                                {
                                    primesList.Add(Convert.ToInt32(i));
                                    return;
                                }
                            }

                            else
                            {
                                return;
                            }
                        }

                        for (int k = 3; k * k <= Convert.ToInt32(i); k += 2)
                        {
                            if (Convert.ToInt32(i) % k == 0)
                            {
                                return;
                            }
                        }
                        lock (primesList)
                        {
                            primesList.Add(Convert.ToInt32(i));
                        }
                    });
            }
            return primesList;
        }
    }
}

