using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Module : BaseClass
    {
        public  string Title { get; set; }
        private double _totaltime;
        public Guid CourseId { get;  private set; }= default!;
        public ICollection<Lesson> Lessons { get; set; } 
        public double TotalTime { get
        {
            return _totaltime;
        }

        set
        {
            _totaltime = CalculateTotaltime();
        } }
        public Quiz Quiz { get; set; }= default!; 
        public Course Course{get;set;}
       internal Module(string title, Guid courseId)
       {
            Title = title;
            CourseId = courseId;
            Lessons = new HashSet<Lesson>();
       }
       private Module()
       {

       }
       public void SetQuiz(Quiz quiz)
       {
            if (quiz == null)
            {
                throw new ArgumentException("Quiz cannot be null");
            }
            if (quiz.ModuleId != this.Id)
            {
                throw new ArgumentException("Wrong ModuleId passed");
            }
            Quiz = quiz;
       }
       public void RemoveQuiz()
       {
           Quiz = null; 
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
    
        // public void UpdateLesson(Lesson updatedLesson)
        // {
        //     var existingLessons = Lessons.FirstOrDefault(x => x.Id == updatedLesson.Id);
        //     if (existingLessons != null)
        //     {
        //         existingLessons.File = updatedLesson.File;
        //         existingLessons.Topic = updatedLesson.Topic;
        //         existingLessons.TotalMinutes = updatedLesson.TotalMinutes;
        //     }
        // }
        
    }
}