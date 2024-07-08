using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.DTO
{
    public record LessonDto
    {
        public  string Topic { get; set; }
        public string File { get; set; }
        public string Article { get; set; }
        public Guid ModuleId { get; set; }
        public double TotalMinutes { get; set; }
    }
    public record LessonRequestModel
    {
         public  string Topic { get; set; }
        public IFormFile File { get; set; }
        public string? Article { get; set; }
        public Guid ModuleId { get; set; }
        public double TotalMinutes { get; set; }
    }
    public record UpdateLessonRequestModel
    {
        public  string Topic { get; set; }
        public IFormFile File { get; set; }
        public string? Article { get; set; }
        public Guid ModuleId { get; set; }
        public Guid LessonId { get; set; }
        public double TotalMinutes { get; set; }
    }
}