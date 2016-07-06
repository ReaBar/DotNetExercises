using System;
using System.Collections.Generic;
using System.IO;
using FileFinder;

namespace FileFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 2 && !string.IsNullOrWhiteSpace(args[0]) && !string.IsNullOrWhiteSpace(args[1]))
            {
                List<string> filesFound = new List<string>();

                if (Directory.Exists(args[0]))
                {
                    string directory = args[0];
                    string file = args[1];
                    FileFinder fileFinder = new FileFinder();
                    DirectoryInfo dir = new DirectoryInfo(directory);
                    filesFound = fileFinder.FilesFinderRecursion(dir, file);
                }

                if (filesFound != null && filesFound.Count > 0)
                {
                    foreach (var fileFound in filesFound)
                    {
                        Console.WriteLine(fileFound + ", file length: " + new FileInfo(fileFound).Length);
                    }
                }

                else
                {
                    Console.WriteLine("File or Directory not found");
                }
            }

            else
            {
                Console.WriteLine("Unacceptable arguments");
            }
        }
    }
}
