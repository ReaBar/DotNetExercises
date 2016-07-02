using System;
using System.Text;

namespace ShapeLib
{
    public class Ellipse : Shape, IPersist, IComparable
    {
        int _axisA, _axisB;


        public Ellipse()
        {
            _axisA = 0;
            _axisB = 0;
        }

        public Ellipse(ConsoleColor color) : base(color)
        {
            _axisA = 0;
            _axisB = 0;
        }

        public Ellipse(int axisA, int axisB)
        {
            _axisA = axisA;
            _axisB = axisB;
        }

        public Ellipse(int axisA, int axisB, ConsoleColor color) : base(color)
        {
            _axisA = axisA;
            _axisB = axisB;
        }

        public override double Area
        {
            get
            {
                return 3.14 * _axisA * _axisB;
            }
        }

        public int CompareTo(object obj)
        {
            if (obj is Ellipse)
            {
                if (Area > ((Ellipse)obj).Area)
                {
                    return 1;
                }

                else if (Area < ((Ellipse)obj).Area)
                {
                    return -1;
                }

                return 0;
            }
            return -2; //if its not the same type of object
        }


        public override void Display()
        {
            Console.WriteLine("The ellipse axis a is {0} and axis b is {1}", _axisA, _axisB);
        }

        public void Write(StringBuilder sb)
        {
            sb.AppendLine(_axisA.ToString());
            sb.AppendLine(_axisB.ToString());
        }
    }
}
