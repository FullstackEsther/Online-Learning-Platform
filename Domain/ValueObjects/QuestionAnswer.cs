using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.ValueObjects
{
    public class QuestionAnswer
    {
        public string SelectedOption;
        public Guid QuestionId;
        public Question Question { get; set; }
        public Guid ResultId { get; set; }
        public Result Result { get; set; }
        public QuestionAnswer(string selectedOption, Guid questionId, Guid resultId)
        {
            SelectedOption = selectedOption;
            QuestionId = questionId;
            ResultId = resultId;
        }
        private QuestionAnswer()
        {

        }
    }
}