using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class ResultDto
    {
        public double Score { get; set; }
        public bool IsPassedTest { get; set; }
        public QuizDto QuizDto { get; set; }
        
    }
}