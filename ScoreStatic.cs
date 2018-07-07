using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class ScoreStatic
    {
        public Double TotalScore { get; set; }
        public int TotalCreditCount { get; set; }

        public ScoreStatic()
        {
            TotalScore = 0;
            TotalCreditCount = 0;
        }

        public ScoreStatic Accumlate(Score score)
        {
            TotalScore += score.ScoreValue * score.Credit;
            TotalCreditCount += score.Credit;
            return this;
        }

        public Double Computer()
        {
            return TotalScore / (Double)TotalCreditCount;
        }
    }
}
