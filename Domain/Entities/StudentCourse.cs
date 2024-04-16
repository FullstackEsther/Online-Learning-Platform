using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StudentCourse : BaseClass
    {
        public string StudentId { get; set; }
        public string CourseId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}