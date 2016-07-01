using System;
using System.Text;

namespace ShapesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ShapeManager shapeManager = new ShapeManager();
            ShapeLib.Shape circle = new ShapeLib.Circle(3, 4, 5);
            ShapeLib.Shape ellipse = new ShapeLib.Ellipse(1, 2);
            ShapeLib.Shape rectangle = new ShapeLib.Rectangle(2, 4);
            shapeManager.Add(circle);
            shapeManager.Add(ellipse);
            shapeManager.Add(rectangle);
            circle.Display();
            ellipse.Display();
            rectangle.Display();

            Console.WriteLine("number of shapes in the array {0}",shapeManager.Count);
            shapeManager.DisplayAll();
            StringBuilder sb = new StringBuilder();
            shapeManager.Save(sb);
            Console.WriteLine(sb.ToString());

            ShapeLib.Rectangle rectangle2 = new ShapeLib.Rectangle(2,5);
            ShapeLib.Ellipse ellipse2 = new ShapeLib.Ellipse(1, 1);
            Console.WriteLine("rectangle2.CompareTo(rectangle) = {0}",rectangle2.CompareTo(rectangle));
            Console.WriteLine("ellipse2.CompareTo(ellipse) = {0}",ellipse2.CompareTo(ellipse));

            ShapeLib.Ellipse ellipse3 = new ShapeLib.Ellipse(1,2);
            Console.WriteLine("ellipse1 area: {0} , ellipse3 area: {1}",ellipse.Area,ellipse3.Area);
        }
    }
}
