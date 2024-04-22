using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category : BaseClass
    {
        public required string Name { get; set; }
        private string _description;
        public required string Description {
             get => _description;
             set
             {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Description must be 50 characters or fewer.");
                }
                _description = value;
             } 
             }
        public string? ParentCategory {get; set;}
        public IEnumerable<string> Courses { get; set; }= new HashSet<string>();
    }
}