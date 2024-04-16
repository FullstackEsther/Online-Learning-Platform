using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Instructor : BaseClass
    {
        public string UserId { get; set; }
        public User User { get; set; }
       public IEnumerable<Course> Courses { get; set; } = new HashSet<Course>();
    }
}