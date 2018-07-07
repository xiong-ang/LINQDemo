using Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            var scores = Score.GetScore("Score.csv");

            var query = from score in scores
                        group score by score.StuName into StuScores
                        select  new{
                            Name = StuScores.Key,
                            AvgScore = StuScores.Aggregate(new ScoreStatic(), (acc, e) => acc.Accumlate(e), acc => acc.Computer())
                        }into results
                        orderby results.AvgScore descending
                        select results;

            var query2 = scores.GroupBy(s=>s.StuName)
                .Select(g=>{
                    var avgScore = g.Aggregate(new ScoreStatic(), (acc, e)=>acc.Accumlate(e), acc=>acc.Computer());
                    return new
                    {
                        Name = g.Key,
                        AvgScore = avgScore
                    };
                })
                .OrderByDescending(s=>s.AvgScore);

            query.ToList().ForEach(e => {
                Console.WriteLine(e.Name + "\t" + e.AvgScore);
            });
        }
    }
}
