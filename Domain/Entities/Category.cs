using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain.Shared.Exception;

namespace Domain.Entities
{
    public class Category : BaseClass
    {
        public string Name { get; set; }
        private string _description;
        public  string Description {
             get => _description;
             set
             {
                if (value.Length > 200)
                {
                    throw new DomainException("Description must be 200 characters or fewer.");
                }
                _description = value;
             } 
             }
        public string? ParentCategory {get; set;}
        public ICollection<Course> Courses { get; set; }= new HashSet<Course>();
        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }
        private Category()
        {
            
        }
    }
}