using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Enrollment : BaseClass
    {
        public string Feedback{ get; set; } = default!;
        public Guid StudentId { get; set; } = default!;
        public Guid CourseId { get; set; }= default!;
        public Guid? PaymentId { get; set; } = default!;
        public Payment Payment {get;set; } = default!;
        // public Student Student { get; set; }= default!;
        // public Course Course { get; set; }= default!;
    }
}