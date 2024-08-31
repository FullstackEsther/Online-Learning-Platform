using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.DTO
{
    public record InstructorDto
    {
        public Guid Id { get; set; }
        public string ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
        public string Email { get; set; }
    }
    // public record InstructorRequestModel
    // {
    //     public string ProfilePicture { get; set; }
    //     public string FirstName { get; set; }
    //     public string LastName { get; set; }
    //     public string Biography { get; set; }
    // }
    public record UpdateInstructorRequestModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Biography { get; set; }
    }
    public record UpdateInstructorProfilePicture{
        public  IFormFile ProfilePicture { get; set; }
    }
    public record CreateInstructRequestModel()
    {
        public  IFormFile ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
    }
}