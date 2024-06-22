using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class QuizAnswer
    {
        public string OptionText;
        public Guid QuestionId;
        public QuizAnswer(string optionText, Guid questionId)
        {
            OptionText = optionText;
            QuestionId = questionId;
        }
        private QuizAnswer()
        {
            
        }
    }
}