using System;
using System.Text;
using System.Collections;
 
namespace ShapesApp
{
    class ShapeManager
    {
        ArrayList _shapes = new ArrayList();

        public void Add(ShapeLib.Shape shape)
        {
            _shapes.Add(shape);
        }

        public void DisplayAll()
        {
            foreach(ShapeLib.Shape shape in _shapes)
            {
                Console.WriteLine("The area of {0} is {1}",shape.GetType().ToString(),shape.Area.ToString());
                shape.Display();
            }
        }

        public Object this[int key]
        {
            get { return _shapes[key]; }
        }

        public int Count
        {
            get { return _shapes.Count; }
        }

        public void Save(StringBuilder sb)
        {
            foreach (var shape in _shapes)
            {
                if(shape is ShapeLib.IPersist)
                {
                    ((ShapeLib.IPersist)shape).Write(sb);
                }
            }
        }
    }
}
