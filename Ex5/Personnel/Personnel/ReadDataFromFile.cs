using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnel
{
    class ReadDataFromFile
    {
        public void ReadAllDataFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                List<string> data = new List<string>();
                StreamReader str = new StreamReader(fileName);
                string line;
                while ((line = str.ReadLine()) != null)
                {
                    if (!String.IsNullOrWhiteSpace(line))
                    {
                        data.Add(line);
                    }
                }

                foreach (var lineOfText in data)
                {
                    Console.WriteLine(lineOfText);
                }
                str.Close();
            }
        }
    }
}
