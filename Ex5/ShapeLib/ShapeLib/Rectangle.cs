using System;
using System.Text;

namespace ShapeLib
{
    public class Rectangle : Shape,IPersist,IComparable
    {
        int _width, _height;

        public Rectangle(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public Rectangle(int width, int height,ConsoleColor color) : base(color)
        {
            _width = width;
            _height = height;
        }

        public override double Area
        {
            get
            {
                return _height*_width;
            }
        }

        public int CompareTo(object obj)
        {
            if(obj is Rectangle)
            {
                if (Area > ((Rectangle)obj).Area)
                {
                    return 1;
                }

                else if (Area < ((Rectangle)obj).Area)
                {
                    return -1;
                }

                return 0;
            }
            return -2; //if its not the same type of object
        }

        public override void Display()
        {
            Console.WriteLine("The rectangle width is {0} and the height is {1}", _width, _height);
        }

        public void Write(StringBuilder sb)
        {
            sb.AppendLine(_width.ToString());
            sb.AppendLine(_height.ToString());
        }
    }
}
