using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    class Program
    {
        private static void GetBooksInfo()//https://www.dreamincode.net/forums/topic/309456-linq-to-xml-joining-xml-data/
        {
            //http://www.vbforums.com/showthread.php?685154-Counting-Particular-Letter-Occurrences-in-a-String
            XDocument xdDomain = new XDocument(new XElement("Domains",
                                     new XElement("Domain", new XAttribute("Id", "L001"),
                                         new XElement("Name", "LINQ")),
                                     new XElement("Domain", new XAttribute("Id", "C001"),
                                         new XElement("Name", "C#")),
                                     new XElement("Domain", new XAttribute("Id", "A001"),
                                         new XElement("Name", "ASP.Net"))
                                     ));
            //xdDomain.Element("Domain").Attribute("Id","df");

            XDocument xdBooks = new XDocument(new XElement("Books",
                                                new XElement("Book",
                                                    new XElement("Name", "Teach Yourself LINQ in 24 Hours"),
                                                    new XElement("DomainId", "L001")),
                                                 new XElement("Book",
                                                    new XElement("Name", "Pro LINQ"),
                                                    new XElement("DomainId", "L001")),
                                                  new XElement("Book",
                                                    new XElement("Name", "C# Illustated 2010"),
                                                    new XElement("DomainId", "C001")),
                                                  new XElement("Book",
                                                    new XElement("Name", "Programming with C# 2010"),
                                                    new XElement("DomainId", "C001")),
                                                  new XElement("Book",
                                                    new XElement("Name", "ASP.Net 4-0 Professional"),
                                                    new XElement("DomainId", "A001"))
                                                    ));


            var qry = from b in xdBooks.Descendants("Book")
                      join d in xdDomain.Descendants("Domain")
                      on b.Element("DomainId").Value equals d.Attribute("Id").Value
                      select new { book = b, domain = d };
            Console.WriteLine("==== Domain ====|=========== Title ==========");

            foreach (var item in qry)
            {
                Console.WriteLine("{0,-16}| {1}", item.domain.Element("Name").Value, item.book.Element("Name").Value);
            }
        }
        static void Main(string[] args)
        {
            GetBooksInfo();
        }
    }
}
