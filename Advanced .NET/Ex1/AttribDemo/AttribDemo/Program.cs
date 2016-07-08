using System;
using System.Reflection;

namespace AttribDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyAnalyzer asmAnalyzer = new AssemblyAnalyzer();
            asmAnalyzer.AnalyzeAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
