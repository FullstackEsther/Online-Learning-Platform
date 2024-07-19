using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class QuestionOption
    {
        public Guid QuestionId {get; set;}
        public string Text {get;set;}
        public bool IsCorrect {get;set;}= false;
        internal QuestionOption( string text, bool isCorrect, Guid questionId)
        {
            Text = text ?? throw new ArgumentException("Option text cannot be null");
            IsCorrect = isCorrect;
            QuestionId = questionId;
        }
        public QuestionOption()
        {
            
        }
    }
}