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
                .Select(t => new XElement("Type", new XAttribute("FullName", t.FullName),
                    new XElement("Properties", t.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                        .Select(p => new XElement("Property", new XAttribute("Name", p.Name), new XAttribute("Type", p.PropertyType.Name))))));

        }
    }
}
