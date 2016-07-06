using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Rationals
{
    public struct Rational
    {
        private int _numerator, _denominator;

        public Rational(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                Console.WriteLine("Invalid denominator number, denominator can't be initalized to 0 therefor it was initialized to 1");
                _denominator = 1;
                _numerator = numerator;
            }
            else
            {
                _numerator = numerator;
                _denominator = denominator;
            }
        }

        public Rational(int numerator)
        {
            _numerator = numerator;
            _denominator = 1;
        }

        public int Numerator => _numerator;

        public int Denominator => _denominator;

        public double DoubleNumerator => Convert.ToDouble(_numerator);

        public double DoubleDenominator => Convert.ToDouble(_denominator);

        public Rational Add(int numerator, int denominator)
        {
            int newNumerator = (_numerator*denominator) + (_denominator*numerator);
            int newDenominator = _denominator*denominator;
            return new Rational(newNumerator,newDenominator);
        }

        public Rational Add(Rational rat)
        {
            int newNumerator = (_numerator * rat.Denominator) + (_denominator * rat.Numerator);
            int newDenominator = _denominator * rat.Denominator;
            return new Rational(newNumerator, newDenominator);
        }

        public Rational Mul(int numerator, int denominator)
        {
            int newNumerator = _numerator*numerator;
            int newDenominator = _denominator*denominator;
            return new Rational(newNumerator,newDenominator);
        }

        public Rational Mul(Rational rat)
        {
            int newNumerator = _numerator * rat.Numerator;
            int newDenominator = _denominator * rat.Denominator;
            return new Rational(newNumerator, newDenominator);
        }

        public void Reduce()
        {
            if(_numerator > 1 && _denominator > 1)
            {
                int a = _numerator;
                int b = _denominator;

                while (b != 0)
                {
                    int temp = a;
                    a = b;
                    b = temp % b;
                }

                _numerator /= a;
                _denominator /= a;
            }
        }

        public static Rational operator +(Rational rat1, Rational rat2)
        {
            return rat1.Add(rat2);
        }

        public static Rational operator -(Rational rat1, Rational rat2)
        {
            int newNumerator = (rat1.Numerator*rat2.Denominator) - (rat1.Denominator*rat2.Numerator);
            int newDenominator = rat1.Denominator*rat2.Denominator;
            return new Rational(newNumerator,newDenominator);
        }

        public static Rational operator /(Rational rat1, Rational rat2)
        {
            int newNumerator = rat2.Denominator;
            int newDenominator = rat2.Numerator;
            return rat1.Mul(new Rational(newNumerator, newDenominator));
        }

        public static Rational operator *(Rational rat1, Rational rat2)
        {
            return rat1.Mul(rat2);
        }

        public override bool Equals(object obj)
        {
            Rational rat = (Rational) obj;
            this.Reduce();
            rat.Reduce();
            if(_numerator == rat.Numerator && _denominator == rat.Denominator)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            int divArgument = _numerator/_denominator;
            int newNumerator = _numerator - (_denominator * divArgument);
            if ((divArgument != 0) && (divArgument != _numerator) && (newNumerator != 0))
            {
                return $"{_numerator} / {_denominator} or simplified {divArgument}*({newNumerator}/{_denominator})";
            }
            if (_denominator == 1)
            {
                return $"{_numerator} / {_denominator} or simplified {_numerator}";
            }
            return $"{_numerator} / {_denominator}";
        }
    }
}