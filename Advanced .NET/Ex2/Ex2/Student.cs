using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Average { get; set; }

        internal string Class { get; set; }

        public override string ToString()
        {
            return
                $"Student's name: {Name}\nStudent's Age: {Age}\nStudent's average: {Average}\nStudent's class: {Class}";
        }
    }
}
