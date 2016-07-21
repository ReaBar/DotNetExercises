using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Ex2
{
    class Queries
    {
        public void PublicInterfaceInMscrelib()
        {
            Assembly mscorlib = typeof(string).Assembly;

            var interfaceQuery = mscorlib.GetTypes().Where(p => p.IsInterface).OrderBy(p => p.Name).
                Select(p => new
                {
                    Name = p.Name,
                    NumberOfMethods = p.GetMethods().Length
                });

            foreach (var interfaceFromMscorlib in interfaceQuery)
            {
                Console.WriteLine(interfaceFromMscorlib);
            }
        }

        public void RunningProcesses()
        {
            var runningProcessesQuery =
                Process.GetProcesses().Where(p => this.CheckProcessAccess(p) && p.Threads.Count < 5).OrderBy(p => p.Id).
                Select(p => new
                {
                    ProccesName = p.ProcessName,
                    ProcessId = p.Id,
                    ProcessTime = p.StartTime
                });

            foreach (var runningProcess in runningProcessesQuery)
            {
                Console.WriteLine(runningProcess);
            }
        }

        private bool CheckProcessAccess(Process process)
        {
            try
            {
                var result = process.ProcessName;
            }

            catch (Win32Exception e)
            {
                Console.WriteLine("got Win32Exception " + e.Message);
                return false;
            }

            return true;
        }
    }
}
