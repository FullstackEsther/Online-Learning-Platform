using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain.Shared.Enum;

namespace Domain.Entities
{
    public class Question : BaseClass
    {
        public Guid QuizId { get; set; }= default!;
        public QuestionType QuestionType {get;set;}
        public  string QuestionText { get; set; }
        public ICollection<QuestionOption> Options = new HashSet<QuestionOption>();
        public ICollection<QuizAnswer> Answers = new HashSet<QuizAnswer>();
        internal Question(string questionText)
        {
            QuestionText = questionText;
        }
        private Question()
        {

        }
        public void AddOption(QuestionOption option)
        {
            var checkOption = Options.SingleOrDefault(x => x.Text == option.Text);
            if (checkOption != null) throw new ArgumentException("Option alredy exist");
            Options.Add(option);
        }
        public void RemoveOption(QuestionOption option)
        {
            if(option == null) throw new ArgumentException("option cannot be null");
            Options.Remove(option);
        }

        public void AddAnswer(string optionText)
        {
           var option = Options.SingleOrDefault(x => x.Text == optionText) ?? throw new ArgumentException("Invalid Option");
           var answer = new QuizAnswer(optionText,Id);
           Answers.Add(answer);
        }
        public void RemoveAnswer(string optionText)
        {
            var answer = Answers.SingleOrDefault(x => x.OptionText == optionText) ?? throw new ArgumentException("Invalid Option");
            Answers.Remove(answer);
        }
    }
}