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
        public Guid CourseId { get;  private set; }= default!;
        public ICollection<Lesson> Lessons { get; set; } 
        public string TotalTime { get
        {
            return _totaltime;
        }

        set
        {
            _totaltime = TimeConverter(CalculateTotaltime);
        } }
        // public Course Course { get; set; }= default!;
        // public Quiz Quiz { get; set; }= default!; 
       public Module(string title, Guid courseId)
       {
            Title = title;
            CourseId = courseId;
            Lessons = new HashSet<Lesson>();
       }
       private Module()
       {

       }

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
        public void AddLessons(Lesson lesson)
        {
            if (lesson != null)
            {
                Lessons.Add(lesson);
            }
            else
            {
                throw new ArgumentException("Cannot Add an empty Lesson Object");
            }
        }
        public void RemoveLesson(Guid lessonId)
        {
           var lesson = Lessons.FirstOrDefault(x => x.Id == lessonId);
           Lessons.Remove(lesson!);
        }
    
        public void UpdateLesson(Lesson updatedLesson)
        {
            var existingLessons = Lessons.FirstOrDefault(x => x.Id == updatedLesson.Id);
            if (existingLessons != null)
            {
                existingLessons.File = updatedLesson.File;
                existingLessons.Topic = updatedLesson.Topic;
                existingLessons.TotalMinutes = updatedLesson.TotalMinutes;
            }
        }
        
    }
}