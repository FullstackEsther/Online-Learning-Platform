using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain.Shared.Enum;
using Domain.Entities;
using Domain.Enum;
using Microsoft.AspNetCore.Http;

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
        public IReadOnlyList<ModuleDto> Modules { get; set; }
    }
    public record CourseRequestModel
    {
        public string Title { get; set; }
        public Level Level { get; set; }
        public Guid CategoryId { get; set; }
        public string CourseCode { get; set; }
        public IFormFile DisplayPicture { get; set; }
        public string WhatToLearn { get; set; }
        public CourseStatus CourseStatus { get; set; }
        public IFormFile? profilePicture {get;set;}
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