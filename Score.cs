using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Linq
{
    public class Score
    {
        public int Id { get; set; }
        public string StuName { get; set; }
        public string Subject { get; set; }
        public int ScoreValue { get; set; }
        public int Credit { get; set; }

        public static List<Score> GetScore(string filePath)
        {
            var query = from line in File.ReadAllLines(filePath).Skip(1)
                        select new Score(line);
            return query.ToList(); 
        }

        public Score()
        {

        }

        public Score(string csvLine)
        {
            var props = csvLine.Split(',');
            StuName = props[0];
            Subject = props[1];
            ScoreValue = int.Parse(props[2]);
            Credit = int.Parse(props[3]);
        }
    }
}
