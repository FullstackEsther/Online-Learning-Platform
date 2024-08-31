using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserProgress : BaseClass
    {
        public string UserEmail { get; set; }
        public Guid CourseId { get; set; }
        public Guid LessonId { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CompletionDate { get; set; }
        public UserProgress(string userEmail, Guid courseId, Guid lessonId)
        {
            UserEmail = userEmail;
            CourseId = courseId;
            LessonId = lessonId;
        }
        public void MarkAsCompleted()
        {
            IsCompleted = true;
            CompletionDate = DateTime.Now;
        }
    }
}