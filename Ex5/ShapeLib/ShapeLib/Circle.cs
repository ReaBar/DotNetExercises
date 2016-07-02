using System;

namespace ShapeLib
{
    public class Circle : Ellipse
    {
        int _radius;

        public Circle(int radius,int axisA, int axisB) : base(axisA, axisB)
        {
            _radius = radius;
        }

        public Circle(int radius, int axisA, int axisB, ConsoleColor color) : base(axisA, axisB,color)
        {
            _radius = radius;
        }

        public Circle(int radius)
        {
            _radius = radius;
        }
        
        public override double Area
        {
            get { return 3.14 * Math.Pow(_radius, 2); }
        }

        public override void Display()
        {
            Console.WriteLine("The circle radius is {0}", _radius);
        }
    }
}
