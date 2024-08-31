using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain.Shared.Enum;
using Domain.Domain.Shared.Exception;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Question : BaseClass
    {
        public Guid QuizId { get; set; }= default!;
        public QuestionType QuestionType {get;set;}
        public  string QuestionText { get; set; }
        public  Quiz Quiz { get; set; }
        public ICollection<QuestionOption> Options = new HashSet<QuestionOption>();
        internal Question(string questionText, Guid quizId,QuestionType questionType)
        {
            QuestionType = questionType;
            QuizId = quizId;
            QuestionText = questionText;
        }
        private Question()
        {

        }
        public void AddOption(QuestionOption option)
        {
            var checkOption = Options.SingleOrDefault(x => x.Text == option.Text);
            if (checkOption != null) throw new DomainException("Option alredy exist");
            Options.Add(option);
        }
        public void RemoveOption(QuestionOption option)
        {
            if(option == null) throw new DomainException("option cannot be null");
            Options.Remove(option);
        }

        // public void AddAnswer(string optionText)
        // {
        //    var option = Options.SingleOrDefault(x => x.Text == optionText) ?? throw new ArgumentException("Invalid Option");
        //    var answer = new QuizAnswer(optionText,Id);
        //    Answers.Add(answer);
        // }
        // public void RemoveAnswer(string selectedOption)
        // {
        //     var answer = Answers.SingleOrDefault(x => x.SelectedOption == selectedOption) ?? throw new ArgumentException("Invalid Option");
        //     Answers.Remove(answer);
        // }
    }
}