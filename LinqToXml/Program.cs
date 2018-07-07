using Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqToXml
{
    class Program
    {
        static void Main(string[] args)
        {
            var scores = Score.GetScore("Score.csv");

            string fileName = "Score.xml";
            if (!File.Exists(fileName))
                CreateXML(scores, fileName);
            QueryXML(fileName);
        }

        private static void QueryXML(string fileName)
        {
            XDocument xDoc = XDocument.Load(fileName);

            var query = from score in xDoc.Element("scores").Elements("score")
                        group score by score.Attribute("Name").Value into StuGroup
                        select new
                        {
                            Name = StuGroup.Key,
                            AvgScore =
                                StuGroup.Aggregate(new ScoreStatic(),
                                    (acc, e) 
                                        => acc.Accumlate(new Score
                                            {
                                                ScoreValue = int.Parse(e.Attribute("Score").Value),
                                                Credit = int.Parse(e.Attribute("Credit").Value)
                                            }),
                                    acc => acc.Computer())
                        } into results
                        orderby results.AvgScore descending
                        select results;

            query.ToList().ForEach(e =>
            {
                Console.WriteLine(e.Name + "\t" + e.AvgScore);
            });

        }

        private static void CreateXML(List<Score> scores, string fileName)
        {
            XDocument xDoc = new XDocument();

            xDoc.Add(new XElement("scores",
                from score in scores
                    select new XElement("score",
                        new XAttribute("Name",score.StuName),
                        new XAttribute("Subject",score.Subject),
                        new XAttribute("Score",score.ScoreValue),
                        new XAttribute("Credit",score.Credit))));
            xDoc.Save(fileName);
        }
    }
}
