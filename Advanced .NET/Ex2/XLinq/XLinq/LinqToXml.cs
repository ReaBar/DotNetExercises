using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XLinq
{
    class LinqToXml
    {
        private readonly IEnumerable<XElement> _xmlTree;

        public LinqToXml(IEnumerable<XElement> xmlTree)
        {
            _xmlTree = xmlTree;
        }

        public void TypesWithNoProperties()
        {
            var query = _xmlTree.Where(t =>
            {
                var xElement = t.Element("Properties");
                return xElement != null && !xElement.Descendants().Any();
            })
                .OrderBy(t => (string)t.Attribute("FullName"))
                .Select(t => (string)t.Attribute("FullName"));

            var xAttributes = query as string[] ?? query.ToArray();
            foreach (var xAttribute in xAttributes)
            {
                Console.WriteLine($"{xAttribute}");
            }

            Console.WriteLine($"Number of types without properties: {xAttributes.Count()}");
        }

        public void SumOfMethods()
        {
            var query = _xmlTree.Select(m => m.Element("Methods").Descendants().Count()).Sum();
            Console.WriteLine($"Sum of methods: {query}");
        }

        public void SumOfProperties()
        {
            var query = _xmlTree.Select(p => p.Element("Properties").Descendants().Count()).Sum();
            Console.WriteLine($"Sum of properties: {query}");
        }

        public void MostCommonTypeAsParameter()
        {
            var query = _xmlTree.Descendants("Parameter")
                .GroupBy(t => (string) t.Attribute("Type"))
                .Select(g => new
                {
                    ParameterType = g.Key,
                    ParameterCount = g.Count()
                }).OrderByDescending(p => p.ParameterCount).First();

            Console.WriteLine($"Most common type as parameter: {query}");
        }

        public void SortTypesByNumOfMethods()
        {
            var query = _xmlTree.OrderByDescending(m => m.Descendants("Method").Count())
                .Select(m => new
                {
                    TypeName = (string)m.Attribute("FullName"),
                    MethodsCount = m.Descendants("Method").Count(),
                    PropertyCount = m.Descendants("Property").Count()
                });

            var newXmlTree = query.Select(t => new XElement("Type", new XAttribute("FullName", t.TypeName),
                new XAttribute("MethodCount", t.MethodsCount),
                new XAttribute("PropertyCount", t.PropertyCount)));

            XDocument doc = new XDocument();
            doc.Add(new XElement("XML", newXmlTree));
            doc.Save("3_d_XMLTree_" + DateTime.Now.ToString("dd-MM-yyyy") + ".XML");
        }

        public void GroupAllTypesByNumOfMethods()
        {
            var query = _xmlTree.OrderBy(t => (string)t.Attribute("FullName"))
                .GroupBy(t => new
                {
                    TypeName = (string) t.Attribute("FullName"),
                    MethodCount = t.Descendants("Method").Count()
                }).OrderByDescending(g => g.Key.MethodCount)
                .Select(g => new
                {
                    g.Key.TypeName, g.Key.MethodCount
                });
            
            foreach (var item in query)
            {
                Console.WriteLine(item.TypeName + ", " + item.MethodCount);
            }
        }
    }
}
