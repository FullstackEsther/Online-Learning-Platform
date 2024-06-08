using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DomainServices;
using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Result : BaseClass
    {
        // public string SerializedResponse ;
        public string SerializedResponse { get; private set; }
        public double Score { get; private set; }
        public Guid StudentId { get; set; } = default!;
        public Guid QuizId { get; private set; }= default!;
        public bool IsPassedTest{get; private set;} 
        internal Dictionary<Question, string> Responses;
        // public Student Student { get; set; } = default!;
        private Result()
        {
            
        }
        internal Result(Guid quizId, Guid studentId, Dictionary<Question, string> responses)
        {
            StudentId = studentId;
            QuizId = quizId;
            Responses = responses;
            SerializeResponse();
        }
        public void CheckScore()
        {
            var score = CalculateScore();
            if (score < 80)
            {
                Score = score;
                FailedTest();
                throw new ArgumentException("Retake test, you can only score 80 and above");
                
            }
            else
            {
                PassedTest();
                Score = score;
            }
        }
        private void SerializeResponse()
        {
            if (Responses.Count != 0)
            {
               SerializedResponse =  ResultHelper.SerializeDictionary(Responses);
            }
            else
            {
                throw new ArgumentException("No object to Serialize");
            }

        }
        private double MarkQuiz()
        {
            double correctAnswer = 0;
            foreach (var obj in Responses)
            {
                   if (obj.Key.CorrectAnswer == obj.Value)
                {
                    correctAnswer++;
                }
            }
            return correctAnswer;
        }
        private double CalculateScore()
        {
            if (Responses.Count == 0)
            {
                return 0;
            }
            var score = MarkQuiz();
            var totalscore = score / Responses.Count * 100;
            return totalscore;
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