using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Question : BaseClass
    {
        public string QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public string Text { get; set; }
        public string CorrectAnswer { get; set; }
    }
}