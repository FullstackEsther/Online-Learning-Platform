using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Result : BaseClass
    {
        public double? Score { get; private set; }
        public Result(double? score)
        {
            if (score.HasValue && score < 80)
            {
                throw new ArgumentException("Retake test, you can only score 80 and above");
            }
            Score = score;
        }
        public string QuizId { get; set; } = default!;
        public Quiz Quiz { get; set; } = default!;
        public string StudentId { get; set; } = default!;
        public Student Student { get; set; } = default!;
    }
}