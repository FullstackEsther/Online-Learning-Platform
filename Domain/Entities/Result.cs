using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Result : BaseClass
    {
         public double  Score { get; set; }
        public string  QuizId { get; set; }
        public Quiz  Quiz { get; set; }
        public string StudentId { get; set; }
        public Student Student { get; set; }
    }
}