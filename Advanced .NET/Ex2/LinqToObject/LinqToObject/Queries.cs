using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace LinqToObject
{
    class Queries
    {
        public void PublicInterfaceInMscorlib()
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
                Process.GetProcesses().Where(p => IsProcessValid(p) && p.Threads.Count < 5).OrderBy(p => p.Id).
                    Select(p => new
                    {
                        ProccesName = p.ProcessName,
                        ProcessId = p.Id,
                        ProcessTime = p.StartTime,
                    });

            foreach (var runningProcess in runningProcessesQuery)
            {
                Console.WriteLine(runningProcess);
            }
        }

        public void RunningProcessesGroupBy()
        {
            var runningProcessesQueryGroupBy =
                Process.GetProcesses().Where(p => IsProcessValid(p) && p.Threads.Count < 5)
                    .OrderBy(p => p.Id)
                    .GroupBy(p => new
                    {
                        ProccesName = p.ProcessName,
                        ProcessId = p.Id,
                        ProcessTime = p.StartTime,
                        ProcessBasePriority = p.BasePriority
                    }).OrderBy(g => g.Key.ProcessBasePriority).Select(g => new
                    {
                        ProcessName = g.Key.ProccesName,
                        ProcessId = g.Key.ProcessId,
                        ProcessStartTime = g.Key.ProcessTime,
                        ProcessBasePriority = g.Key.ProcessBasePriority
                    });

            foreach (var processGroup in runningProcessesQueryGroupBy)
            {
                Console.WriteLine(processGroup);
            }
        }

        public void TotalNumberOfThreads()
        {
            var totalNumberOfThreads = Process.GetProcesses().Select(p => p.Threads.Count).Sum();
            Console.WriteLine($"Total number of threads: {totalNumberOfThreads}");
        }

        private bool IsProcessValid(Process process)
        {
            try
            {
                var startTime = process.StartTime;
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

