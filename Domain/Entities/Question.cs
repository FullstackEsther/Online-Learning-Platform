using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Question : BaseClass
    {
        public Guid QuizId { get; set; }= default!;
        public  string AskedQuestion { get; set; }
        public  string CorrectAnswer { get; set; }
        internal Question(string askedQuestion , string correctAnswer)
        {
            AskedQuestion = askedQuestion;
            CorrectAnswer = correctAnswer;
        }
        private Question()
        {

        }
    }
}