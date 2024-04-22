using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Instructor : Profile
    {
       public IEnumerable<Course> Courses { get; set; } = new HashSet<Course>();
    }
}