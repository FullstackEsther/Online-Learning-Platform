using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain.Shared.Enum;
using Domain.Entities;
using Domain.Enum;

namespace Application.DTO
{
    public record CourseDto
    {
        public string Title { get; set; }
        public double TotalTime { get; set; }
        public string WhatToLearn { get; set; }
        public string InstructorName { get; set; }
        public string DisplayPicture { get; set; }
        public string CourseCode { get; set; }
        public bool IsVerified { get; set; }
        public Level Level { get; set; }
        public CourseStatus CourseStatus { get; set; }
        public Guid CategoryId { get; set; } = default!;
        public Guid InstructorId { get; set; } = default!;
        public ICollection<Module> Modules { get; set; } = new HashSet<Module>();
    }
    public record CourseRequestModel
    {
        public string Title { get; set; }
        public Level Level { get; set; }
        public Guid CategoryId { get; set; }
        public string CourseCode { get; set; }
        public string DisplayPicture { get; set; }
        public string WhatToLearn { get; set; }
        public CourseStatus CourseStatus { get; set; }
        public string? ProfilePicture { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Biography{ get; set; }
    }
    public record UpdateCourseRequestModel
    {
    public string Title { get; set; }
    public string CourseCode { get; set; }
    public double? Price { get; set; }
    public string DisplayPicture { get; set; }
    public string WhatToLearn { get; set; }
    public Level Level { get; set; }
    public CourseStatus CourseStatus { get; set; }
    public Guid CategoryId { get; set; }
}
}