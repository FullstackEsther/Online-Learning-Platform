using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain.Shared.Exception;

namespace Domain.Entities
{
    public class Module : BaseClass
    {
        public string Title { get; set; }
        private double _totaltime;
        public virtual Course Course { get; set; }
        public Guid CourseId { get; private set; }
        public ICollection<Lesson> Lessons { get; set; }
        public double TotalTime
        {
            get
            {
                return _totaltime;
            }

            set
            {
                _totaltime = CalculateTotaltime();
            }
        }
        public Quiz Quiz { get; set; } = default!;
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
                throw new DomainException("Quiz cannot be null");
            }
            if (quiz.ModuleId != this.Id)
            {
                throw new DomainException("Wrong ModuleId passed");
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
            if (Lessons != null && Lessons.Count != 0)
            {
                foreach (var lesson in Lessons)
                {
                    totaltime += lesson.TotalMinutes;
                }
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
                throw new DomainException("Cannot Add an empty Lesson Object");
            }
        }
        public void RemoveLesson(Guid lessonId)
        {
            var lesson = Lessons.FirstOrDefault(x => x.Id == lessonId) ?? throw new DomainException("Lesson  not Found");
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
