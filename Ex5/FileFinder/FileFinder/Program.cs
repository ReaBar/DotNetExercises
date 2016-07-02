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
            string directory, file;
            if (args.Length == 2)
            {
                if (args[0] is string && args[1] is string)
                {
                    directory = args[0];
                    file = args[1];
                    Program program = new Program();

                    if (Directory.Exists(directory))
                    {
                        DirectoryInfo dir = new DirectoryInfo(directory);
                        filesFound = program.FilesFinderRecursion(dir, file);
                    }
                }
            }
            else if (args.Length > 2)
            {
                StringBuilder sb = new StringBuilder();
                int count = 0;
                for (int i = 0; i < args.Length - 1; i++)
                {
                    if (args[i] is string)
                    {
                        sb.Append(args[i]);
                        sb.Append(' ');
                        count++;
                    }
                }
                if (sb.Length != 0)
                {
                    Program program = new Program();
                    file = args[count];
                    directory = sb.ToString();
                    if (Directory.Exists(directory))
                    {
                        DirectoryInfo dir = new DirectoryInfo(directory);
                        filesFound = program.FilesFinderRecursion(dir, file);
                    }
                }
            }

            if (filesFound.Count > 0)
            {
                foreach (var fileFound in filesFound)
                {
                    Console.WriteLine(fileFound + ", file length: " + new FileInfo(fileFound).Length);
                }
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
