using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO
{
    public record InstructorDto
    {
        public string ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography{ get; set; }
        public string Email{ get; set; }
    }
    public record InstructorRequestModel
    {
        public string ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography{ get; set; }
    }
    public record UpdateInstructorRequestModel
    {
        public string? ProfilePicture { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Biography{ get; set; }
    }
}