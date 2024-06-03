using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Quiz : BaseClass
    {
        private double _duration;
        public double Duration{
             get{
                return _duration;
             } 
             set{
                    if ( value <=0)
                    {
                        throw new ArgumentException("Duration cannot be zero or lower than zero");
                    }
                    _duration = value;
             } } 
        public ICollection<Question> Questions { get; set; }
        public Guid ModuleId { get; private set; }= default!;
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
            if (question != null)
            {
                Questions.Add(question);
            }
            else
            {
                throw new ArgumentException("Cannot add an empty Question");
            }   
        }
        public void DeleteQuestion(Question question)
        {
            var obtainedQuestion = Questions.FirstOrDefault(x => x.Id == question.Id);
            Questions.Remove(obtainedQuestion);
        }

        public void UpdateQuestion(Question updatedQuestion)
        {
            var existingQuestion = Questions.FirstOrDefault(x => x.Id == updatedQuestion.Id);
            if (existingQuestion != null)
            {
                existingQuestion = updatedQuestion;
            }
            else
            {
                throw new ArgumentException("Cannot update a non-existent Question");
            }
        }
    }
}