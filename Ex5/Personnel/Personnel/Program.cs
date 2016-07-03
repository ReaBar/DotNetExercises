using System;
using System.IO;
using System.Collections.Generic;

namespace Personnel
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\names.txt";
            Program p = new Program();
            p.ReadDataFromFile(path);
        }

        public void ReadDataFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                List<string> data = new List<string>();
                StreamReader str = new StreamReader(fileName);
                string line;
                while((line = str.ReadLine()) != null)
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
