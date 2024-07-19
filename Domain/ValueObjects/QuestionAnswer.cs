using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.ValueObjects
{
    public class QuestionAnswer
    {
        public ICollection<string> SelectedOptions;
        public Guid QuestionId;
        public Guid QuizId { get; set; }
        public Question Question { get; set; }
        public QuestionAnswer(ICollection<string> selectedOptions, Guid questionId, Guid quizId)
        {
            SelectedOptions = selectedOptions;
            QuestionId = questionId;
            QuizId = quizId;
        }
        public QuestionAnswer()
        {

        }
    }
}