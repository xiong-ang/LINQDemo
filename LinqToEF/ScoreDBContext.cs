using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linq;

namespace LinqToEF
{
    class ScoreDBContext:DbContext
    {
        public DbSet<Score> Scores { get; set; }
        public ScoreDBContext():base("Score")
        {

        }
    }
}
