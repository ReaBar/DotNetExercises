using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace XLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var linqToXml = Assembly.GetAssembly(typeof(string)).GetExportedTypes().Where(p => p.IsClass)
                .Select(p => new XElement("Type", new XAttribute("FullName", p.FullName),
                    new XElement("Properties", p.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                        .Select(t => new XElement("Property", new XAttribute("Name", t.Name), new XAttribute("Type", t.GetType()))))));

        }
    }
}
