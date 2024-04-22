using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student : Profile
    {
        public IEnumerable<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
        public IEnumerable<Result> Results { get; set; } = new HashSet<Result>();
    }
}