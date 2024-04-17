using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Instructor : BaseClass, IProfile
    {
        public string UserId { get; set; }
        public User User { get; set; }
       public IEnumerable<Course> Courses { get; set; } = new HashSet<Course>();
        public string? Biography { get; set; }
        public string? ProfilePicture { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; }= default!;
    }
}