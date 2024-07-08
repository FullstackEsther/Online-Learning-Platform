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
        public QuizDto Quiz { get;  set; }
        public IReadOnlyList<LessonDto> Lessons { get; set; } 
    }
}