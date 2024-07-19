using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Quiz : BaseClass
    {
        private double _duration;
        public double Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Duration cannot be zero or lower than zero");
                }
                _duration = value;
            }
        }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Result> Result { get; set; } = new HashSet<Result>();
        public Guid ModuleId { get; private set; }
        public Module Module { get; private set; }
        ICollection<QuestionAnswer> answers = new HashSet<QuestionAnswer>();
        public Quiz(double duration, Guid moduleId)
        {
            Duration = duration;
            ModuleId = moduleId;
            Questions = new HashSet<Question>();
        }
        private Quiz()
        {

        }
        public void AddQuestion(Question question)
        {
            var check = Questions.SingleOrDefault(x => x.QuestionText == question.QuestionText);
            if (check != null) throw new ArgumentException("Duplicate Question");
            Questions.Add(question);
        }
        public void DeleteQuestion(Guid questionId)
        {
            var obtainedQuestion = Questions.FirstOrDefault(x => x.Id == questionId) ?? throw new ArgumentException("Question doesnot exist");
            Questions.Remove(obtainedQuestion);
        }
        public void UpdateQuestion(Question question)
        {
            var existingQuestion = Questions.SingleOrDefault(x => x.QuestionText == question.QuestionText) ?? throw new ArgumentException("Question does not exist");
            existingQuestion.QuestionText = question.QuestionText;
            existingQuestion.QuestionType = question.QuestionType;
        }

        public void AddResult(Result result)
        {
            var check = Result.SingleOrDefault(x => x.Id == result.Id);
            if (check != null) throw new ArgumentException("Result already exist");
            Result.Add(result);
        }
        public void DeleteResult(Guid resultId)
        {
            var obtainedResult = Result.FirstOrDefault(x => x.Id == resultId) ?? throw new ArgumentException("Result not Found");
            Result.Remove(obtainedResult);
        }
        public ICollection<QuestionAnswer>  GenerateAnswers(Guid questionId, List<string> selectedOptions)
        {
            var questionAnswer = new QuestionAnswer(selectedOptions,questionId, this.Id);
            answers.Add(questionAnswer);
            return answers;
        }
    }
}