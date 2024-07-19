using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.DTO
{
    public record StudentDto
    {
        public string ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
        public string Email { get; set; }
    }
    public record CreateStudentProfileRequestModel
    {
        public IFormFile? ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
    }
    public record UpdateStudentProfileRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }

    }
}