using System;
using System.IO;
using System.Threading;

namespace SyncDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string _dataTxt = "data.txt";
            string _tmpFolder = @"c:\temp\";
            Mutex _mutex = new Mutex(false, "SyncFileMutex");

            if (!Directory.Exists(_tmpFolder))
            {
                Directory.CreateDirectory(_tmpFolder);
            }

            if (!File.Exists(string.Concat(_tmpFolder,_dataTxt)))
            {
                File.Create(string.Concat(_tmpFolder, _dataTxt));
            }

            for (int i = 0; i < 10000; i++)
            {
                try
                {
                    _mutex.WaitOne();
                    using (StreamWriter streamWriter = new StreamWriter(string.Concat(_tmpFolder, _dataTxt), true))
                    {
                        streamWriter.WriteLine("process identifier: " +
                                               System.Diagnostics.Process.GetCurrentProcess().Id);
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine($"Caught IOException: {e.Message}");
                }

                finally
                {
                    _mutex.ReleaseMutex();
                }
            }
        }
    }
}

