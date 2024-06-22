using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.DTO
{
    public class ModuleDto
    {
        public  string Title { get; set; }
        public double Totaltime{ get;  set; }
        public Guid CourseId { get;  set; }
        public Quiz Quiz { get;  set; }
        public ICollection<Lesson> Lessons { get; set; } 
    }
}