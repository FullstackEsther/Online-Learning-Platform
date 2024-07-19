using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain.Shared.Enum;
using Domain.Entities;
using Domain.Enum;

namespace Domain.DomainServices.Interface
{
    public interface IInstructorManager
    {
          Task<Course> CreateCourse(string title, Level level, Guid categoryId, string courseCode, CourseStatus courseStatus, string whatToLearn, string displayPicture, string email,double price);
          public Task<Instructor> GetProfile(string email);
          public  Task<Instructor> EditProfile(string email, string biography, string firstName, string Lastname, string profilePicture);
          public  Task<Instructor> CreateProfile(string email, string biography, string firstName, string Lastname, string profilePicture);
    }
}