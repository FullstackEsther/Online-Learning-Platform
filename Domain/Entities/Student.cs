using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student :BaseClass
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
        public IEnumerable<Result> Results { get; set; } = new HashSet<Result>();
    }
}