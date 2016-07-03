using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileFinder
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> filesFound = new List<string>();
            if (args.Length == 2 && !string.IsNullOrWhiteSpace(args[0]) && !string.IsNullOrWhiteSpace(args[1]))
            {
                if (Directory.Exists(args[0]))
                {
                    string directory = args[0];
                    string file = args[1];
                    Program program = new Program();
                    DirectoryInfo dir = new DirectoryInfo(directory);
                    filesFound = program.FilesFinderRecursion(dir, file);
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

        public List<string> FilesFinderRecursion(DirectoryInfo directory, string fileName)
        {
            List<string> fileList = new List<string>();

            try
            {
                foreach (var file in directory.GetFiles())
                {
                    FileInfo fileInfo = new FileInfo(file.Name);
                    string fname = fileInfo.Name;
                    if (fname.Contains(fileName))
                    {
                        fileList.Add(file.FullName);
                    }
                }

                foreach (var dir in directory.GetDirectories())
                {
                    var filesFound = FilesFinderRecursion(dir, fileName);
                    if (filesFound != null)
                    {
                        fileList.AddRange(filesFound);
                    }
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Caught UnauthorizedAccessException :\n" + e.Message);
                return null;
            }
            catch (PathTooLongException e)
            {
                Console.WriteLine("Caught PathTooLongException :\n" + e.Message);
                return null;
            }

            if (fileList.Count != 0)
            {
                return fileList;
            }

            return null;
        }
    }
}
