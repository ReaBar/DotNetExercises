using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public abstract class Shape
    {
        double area;
        ConsoleColor _color;
        protected Shape(ConsoleColor color)
        {
            _color = color;
        }

        protected Shape()
        {
            _color = ConsoleColor.White;
        }

        virtual public void Display()
        {
            Console.BackgroundColor = _color;
        }

        public abstract double Area
        {
            get;
        }
    }
}
