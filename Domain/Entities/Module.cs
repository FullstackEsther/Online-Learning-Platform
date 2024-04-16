using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Module : BaseClass
    {
        public string Title { get; set; }
        public TimeSpan TotalTime { get; set; }
        public string CourseId { get; set; }
        public Course Course { get; set; }
        public Quiz Quiz { get; set; }
        public IEnumerable<Lesson> Lessons { get; set; } = new HashSet<Lesson>();
    }
}