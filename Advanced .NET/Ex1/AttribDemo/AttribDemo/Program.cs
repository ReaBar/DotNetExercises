using System;
using System.Reflection;

namespace AttribDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyAnalyzer asmAnalyzer = new AssemblyAnalyzer();
            var codeApproved = asmAnalyzer.AnalyzeAssembly(Assembly.GetExecutingAssembly())
                ? "All the code was approved"
                : "Not all the code was approved";
            Console.WriteLine(codeApproved);
        }
    }
}
