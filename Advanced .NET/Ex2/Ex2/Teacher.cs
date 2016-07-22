using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    class Teacher
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Class { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"Teacher's name: {Name}\nTeacher's age: {Age}\nTeacher's class: {Class}\nTeacher's Salary: {Salary}";
        }
    }
}
