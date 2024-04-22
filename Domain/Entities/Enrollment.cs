using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Enrollment : BaseClass
    {
        public string StudentId { get; set; } = default!;
        public string CourseId { get; set; }= default!;
        public Student Student { get; set; }= default!;
        public Course Course { get; set; }= default!;
    }
}