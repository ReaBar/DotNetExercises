using System;

namespace Rationals {
    class Program
    {
        static void Main(string[] args)
        {
            Rational rat1 = new Rational(16,4);
            Console.WriteLine("rat1.ToString() = {0}",rat1.ToString());
            rat1.Reduce();
            Console.WriteLine("rat1.Reduce() = {0}",rat1.ToString());
            Rational rat2 = new Rational(16,4);
            Console.WriteLine("rat2.ToString() = {0}", rat2.ToString());
            Console.WriteLine("rat2.Equals(rat1) = {0}", rat2.Equals(rat1).ToString());
            Rational rat3 = new Rational(1,2);
            Console.WriteLine("rat3.ToString() = {0}", rat3.ToString());
            Rational rat4 = rat3.Mul(rat1);
            Console.WriteLine("rat4 = rat3 * rat1 => {0}",rat4.ToString());
            rat4.Reduce();
            Console.WriteLine("rat4.Reduce() = {0}",rat4.ToString());
            Rational rat5 = rat3.Add(rat2);
            Console.WriteLine("rat5 = rat3 + rat2 => {0}",rat5.ToString());
            rat5.Reduce();
            Console.WriteLine("rat5.Reduce() = {0}",rat5.ToString());

            Console.WriteLine("Property thats returns double test: {0:N1}/{1:N1}",rat1.DoubleNumerator,rat1.DoubleDenominator);

            Rational rat6 = new Rational(8,0);
            Console.WriteLine($"rat6 initalized with 0 => {rat6.ToString()}");

            Rational rat7 = new Rational(4,2);
            Rational rat8;
            Console.WriteLine($"{rat7.ToString()} add to {rat6.ToString()} using operator + overloading = {rat8 = rat6 + rat7}");

            Rational rat9 = new Rational(-4,-0);
            Console.WriteLine($"{rat7.ToString()} + {rat9.ToString()} = {rat7+rat9}");

            Rational rat10 = new Rational(5);
            Console.WriteLine($"{rat8.ToString()} divide to {rat10.ToString()} using operator / overloading = {rat8 / rat10}");
        }
    }
}
