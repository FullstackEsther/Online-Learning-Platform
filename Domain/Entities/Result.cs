using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DomainServices;
using Domain.ValueObjects;
using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Result : BaseClass
    {
        private double _score;
        public double Score { 
            get => _score;
             private set
             {
                _score = value;
                CalculateScore();
             } }
        public Guid StudentId { get; set; } = default!;
        public Guid QuizId { get; private set; } = default!;
        public bool IsPassedTest { get; private set; }
        public ICollection<QuestionAnswer> QuestionAnswers { get; private set; } 
        public Student Student { get; set; }
        public Quiz Quiz { get; set; }
        private Result()
        {

        }
        internal Result(Guid quizId, Guid studentId, ICollection<QuestionAnswer> questionAnswers)
        {
            StudentId = studentId;
            QuizId = quizId;
            QuestionAnswers = questionAnswers;
        }
        public void CheckScore()
        {
            if (_score < 80)
            {
                FailedTest();
                throw new ArgumentException("Retake test, you can only score 80 and above");

            }
            PassedTest();
        }
        private double MarkQuiz()
        {
            double correctAnswer = 0;
            foreach (var answer in QuestionAnswers)
            {
                var question = Quiz.Questions.FirstOrDefault(x => x.Id == answer.QuestionId) ?? throw new ArgumentException("Invalid Question");
                var correctOptions = question.Options.Where(x => x.IsCorrect == true).Select(x => x.Text);
                if (correctOptions.All(x => answer.SelectedOptions.Contains(x)) && correctOptions.Count() == answer.SelectedOptions.Count())
                {
                    correctAnswer++;
                }
            }
            return correctAnswer;
        }
        private void CalculateScore()
        {
            var score = MarkQuiz();
            Score = score / Quiz.Questions.Count * 100;
        }
        private void PassedTest()
        {
            IsPassedTest = true;
        }
        private void FailedTest()
        {
            IsPassedTest = false;
        }
    }
}