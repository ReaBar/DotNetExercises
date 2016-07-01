using System;
using System.Collections.Generic;
using System.IO;

namespace FileFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string directory, file;
            if (args.Length == 2)
            {
                if (args[0] is string)
                {
                    directory = args[0];
                }

                if (args[1] is string)
                {
                    file = args[1];
                }
            }
        }

        public void FilesFinder(string directory, string fileName)
        {
            if (Directory.Exists(directory))
            {
                string[] filePaths = Directory.GetFiles(directory, fileName, SearchOption.AllDirectories);
                foreach (var item in filePaths)
                {
                    FileInfo fileInfo = new FileInfo(item);
                    Console.WriteLine("file path: {0}, file length: {1} ",item,fileInfo.Length);
                }
            }
        }

        public List<string> FilesFinderRecursion(string directory, string fileName)
        {
            List<string> fileList = new List<string>();
            if (Directory.Exists(directory))
            {
                string[] files = Directory.GetFiles(directory);

                foreach (var file in files)
                {
                    if (File.Exists(file))
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        string fname = fileInfo.Name;
                        if (fname.Contains(fileName))
                        {
                            fileList.Add(file);
                        }
                    }

                    else if (Directory.Exists(file))
                    {
                        fileList.AddRange(FilesFinderRecursion(file, fileName));
                    }
                }

                if(fileList.Count != 0)
                {
                    return fileList;
                }

                return null;
            }

            return null;
        }
    }
}
