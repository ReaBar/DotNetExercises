namespace Personnel
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\names.txt";
            ReadDataFromFile readData = new ReadDataFromFile();
            readData.ReadAllDataFromFile(path);
        }
    }
}
