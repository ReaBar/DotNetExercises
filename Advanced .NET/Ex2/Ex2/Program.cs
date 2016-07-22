using System;
using System.Xml;

namespace Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            Queries linqQueries = new Queries();
            //linqQueries.PublicInterfaceInMscorlib();
            //linqQueries.RunningProcesses();
            //linqQueries.RunningProcessesGroupBy();
            //linqQueries.TotalNumberOfThreads();
            Student st = new Student();
            st.Name = "Rea";
            st.Average = 99.9;
            st.Class = "8th grade";
            st.Age = 15;

            Teacher teacher = new Teacher();
            teacher.Age = 52;
            teacher.Class = "10th grade";
            teacher.Name = "Sarah";
            teacher.Salary = 9999;

            Console.WriteLine("\nBefore CopyTo\n");
            Console.WriteLine(teacher.ToString());
            st.CopyTo(teacher);
            Console.WriteLine("\nAfter CopyTo\n");
            Console.WriteLine(st.ToString() + "\n");
            Console.WriteLine(teacher.ToString());
        }
    }
}
