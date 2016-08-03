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
            List<long> primeList = CalcPrimes(2, 1000, -1);
            foreach (var l in primeList)
            {
                Console.WriteLine("prime: " + l);
            }
        }

        public static List<long> CalcPrimes(int subtracted, int subtrahend, int degreeOfParallelism)
        {
            List<long> primesList = new List<long>();
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            if (subtracted > 1 && subtrahend > 1 && subtrahend > subtracted)
            {
                Parallel.For(subtracted, subtrahend,
                    new ParallelOptions() {MaxDegreeOfParallelism = degreeOfParallelism > 0 ? degreeOfParallelism : -1},
                    i =>
                    {
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
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            return primesList;
        }
    }
}

