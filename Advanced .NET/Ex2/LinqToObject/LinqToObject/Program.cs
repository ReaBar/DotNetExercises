using System;

namespace LinqToObject
{
    class Program
    {
        static void Main(string[] args)
        {
            Queries linqQueries = new Queries();
            linqQueries.PublicInterfaceInMscorlib();
            linqQueries.RunningProcesses();
            linqQueries.RunningProcessesGroupBy();
            linqQueries.TotalNumberOfThreads();
            Student st = new Student
            {
                Name = "Rea",
                Average = 99.9,
                Class = "8th grade",
                Age = 15,
                Discipline = 10
            };

            Teacher teacher = new Teacher
            {
                Age = 52,
                Class = "10th grade",
                Name = "Sarah",
                Salary = 9999,
                Discipline = "rough"
            };

            Console.WriteLine("\nBefore CopyTo\n");
            Console.WriteLine(teacher.ToString());
            st.CopyTo(teacher);
            Console.WriteLine("\nAfter CopyTo\n");
            Console.WriteLine(st.ToString() + "\n");
            Console.WriteLine(teacher.ToString());
        }
    }
}
