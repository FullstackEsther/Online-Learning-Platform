using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class QuestionOption
    {
        // public Guid Id = Guid.NewGuid();
        // public Guid QuestionId {get; set;}
        public string Text {get;set;}
        public bool IsCorrect {get;set;}= false;
        public QuestionOption( string text, bool isCorrect)
        {
            Text = text ?? throw new ArgumentException("Option text cannot be null");
            IsCorrect = isCorrect;
        }
        private QuestionOption()
        {
            
        }
    }
}