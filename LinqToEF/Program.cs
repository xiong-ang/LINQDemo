using Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToEF
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ScoreDBContext>());

            var scores = Score.GetScore("Score.csv");
           
            CreateDB(scores);
            QueryDB();
        }

        private static void QueryDB()
        {
            ScoreDBContext db = new ScoreDBContext();

            //IQuery VS IEnumable
            //var query = from score in db.Scores
            //            group score by score.StuName into StuGroup
            //            select new
            //            {
            //                Name = StuGroup.Key,
            //                AvgScore = StuGroup.Aggregate(new ScoreStatic(), (acc, e) => acc.Accumlate(e), acc => acc.Computer())
            //            } into results
            //            orderby results.AvgScore
            //            select results;

            var query = db.Scores.GroupBy(s => s.StuName)
                .ToList()
                .Select(g =>
                {
                    return new
                    {
                        Name = g.Key,
                        AvgScore = g.Aggregate(new ScoreStatic(), (acc, e) => acc.Accumlate(e), acc => acc.Computer())
                    };
                })
                .OrderByDescending(r => r.AvgScore);


            query.ToList().ForEach(e =>
            {
                Console.WriteLine(e.Name + "\t" + e.AvgScore);
            });
        }

        private static void CreateDB(List<Score> scores)
        {
            ScoreDBContext db = new ScoreDBContext();
            if (db.Scores.Any())
                return;
            db.Scores.AddRange(scores);
            db.SaveChanges();
        }
    }
}
