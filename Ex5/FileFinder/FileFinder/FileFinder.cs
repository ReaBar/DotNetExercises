using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder
{
    class FileFinder
    {
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
