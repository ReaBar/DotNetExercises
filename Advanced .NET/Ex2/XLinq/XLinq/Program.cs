using System;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace XLinq
{
    class Program
    {
        static void Main(string[] args)
        {

            var xmlTree = Assembly.GetAssembly(typeof(string)).GetExportedTypes().Where(p => p.IsClass && p.IsPublic)
                .Select(t => new XElement("Type", new XAttribute("FullName", t.FullName),
                    new XElement("Properties", t.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                        .Select(p => new XElement("Property", new XAttribute("Name", p.Name), new XAttribute("Type", p.PropertyType.Name)))),
                    new XElement("Methods", t.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                        .Select(m => new XElement("Method", new XAttribute("Name", m.Name), new XAttribute("ReturnType", m.ReturnType),
                            new XElement("Parameters", m.GetParameters()
                                .Select(p => new XElement("Parameter", new XAttribute("Name", p.Name), new XAttribute("Type", p.ParameterType.Name)))))))));

            XDocument doc = new XDocument();
            doc.Add(new XElement("XML", xmlTree));
            doc.Save("XMLTree_" + DateTime.Now.ToString("dd-MM-yyyy") + ".XML");

            LinqToXml linqToXml = new LinqToXml(xmlTree);
            linqToXml.TypesWithNoProperties();
            linqToXml.SumOfMethods();
            linqToXml.SumOfProperties();
            linqToXml.MostCommonTypeAsParameter();
            linqToXml.SortTypesByNumOfMethods();
            linqToXml.GroupAllTypesByNumOfMethods();
            
        }
    }
}
