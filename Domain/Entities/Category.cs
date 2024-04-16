using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category : BaseClass
    {
         public required string Name { get; set; }
        public required string Description { get; set; }
        public IEnumerable<SubCategory> SubCategories { get; set;} = new HashSet<SubCategory>();
    }
}