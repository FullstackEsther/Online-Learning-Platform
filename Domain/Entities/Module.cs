using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Module : BaseClass
    {
        public required string Title { get; set; }
        private string _totaltime;
        public string TotalTime { get
        {
            return _totaltime;
        }

        set
        {
            _totaltime = TimeConverter(CalculateTotaltime);
        } }
        public string CourseId { get; set; }= default!;
        public Course Course { get; set; }= default!;
        public Quiz Quiz { get; set; }= default!;
        public IEnumerable<Lesson> Lessons { get; set; } = new HashSet<Lesson>();

        private double CalculateTotaltime()
        {
            double totaltime = 0;
            foreach (var time in Lessons)
            {
                totaltime += time.TotalMinutes;
            }
            return totaltime;
        }
        private string TimeConverter(Func<double> method )
        {
            double timeCalculated = method();
            string ConvertedTime = $"{CalculateHoursMinutesAndSeconds( timeCalculated ).Item1}:{CalculateHoursMinutesAndSeconds( timeCalculated ).Item2}:{CalculateHoursMinutesAndSeconds( timeCalculated ).Item3}" ;
            return ConvertedTime;
        }
         private (double, double,double) CalculateHoursMinutesAndSeconds(double time)
        {
            var totalSeconds = time * 60;
            var hours = totalSeconds/3600;
            var remainingSeconds = totalSeconds%3600;
            var minutes = remainingSeconds/60;
            var seconds = minutes% 60;
            return(hours, minutes, seconds);
        }
        
    }
}