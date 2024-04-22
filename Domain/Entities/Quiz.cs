using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Quiz : BaseClass
    {
        private double _score;
        public double? Score
        {
            get { return CalculateScore(); }
            set{
                if (value.HasValue)
                {
                    
                    _score = (double)value;
                }
            }
        }
        public string ModuleId { get; set; }= default!;
        public Module Module { get; set; }= default!;
        public Result Result { get; set; }= default!;
        public IEnumerable<Question> Questions { get; set; } = new HashSet<Question>();

        private double CorectAnswers()
            {
                _score = 0;
                foreach (var question in Questions)
                {
                    if (question.PickedAnswer!= null && question.PickedAnswer == question.CorrectAnswer)
                    {
                        _score++;
                    }
                }
                return _score;
            }
            private double CalculateScore()
            {
                if (Questions.Count() == 0)
                {
                    return 0;
                }
                var score = CorectAnswers();
                var totalscore = score / Questions.Count()*100;
                return totalscore;
            }
        
        
    }
}