using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Question : BaseClass
    {
        public Guid QuizId { get; set; }= default!;
        public required string AskedQuestion { get; set; }
        public required string CorrectAnswer { get; set; }
    }
}