using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enum;

namespace Domain.Entities
{
    public class Course : BaseClass
    {
        public string Title { get; set; } = default!;
        public string InstructorId { get; set; } = default!;
        public double? Price { get; set; }
        public TimeSpan TotalTime { get; set; }
        public CourseStatus CourseStatus { get; set; }
        public string SubCategoryId { get; set; } = default!;
        public SubCategory SubCategory { get; set; } = default!;
        public Instructor Instructor { get; set; } = default!;
        public IEnumerable<Module> Modules { get; set; } = new HashSet<Module>();
        public IEnumerable<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
    }
}