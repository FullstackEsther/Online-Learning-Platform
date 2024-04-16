using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SubCategory : BaseClass
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string CategoryId { get; set; }
        public  Category Category { get; set; }
        public  IEnumerable<Course> Courses { get; set; } = new HashSet<Course>();
    }
}