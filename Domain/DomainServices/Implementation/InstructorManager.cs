using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain.Shared.Enum;
using Domain.Domain.Shared.Exception;
using Domain.DomainServices.Interface;
using Domain.Entities;
using Domain.Enum;
using Domain.RepositoryInterfaces;
using PayStack.Net;

namespace Domain.DomainServices.Implementation
{
    public class InstructorManager : IInstructorManager
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly ICourseManager _courseManager;
        public InstructorManager(IInstructorRepository instructorRepository, ICourseManager courseManager)
        {
            _instructorRepository = instructorRepository;
            _courseManager = courseManager;
        }
        public async Task<Course> CreateCourse(string title, Level level, Guid categoryId, string courseCode, CourseStatus courseStatus, string whatToLearn, string displayPicture, string email,double? price)
        {
            var existingInstructor = await _instructorRepository.GetInstructor(x => x.Email == email);
            var course = await _courseManager.CreateCourse(title, level, categoryId, courseCode, courseStatus, whatToLearn, displayPicture, email,price);
            course.InstructorId = existingInstructor.Id;
            course.InstructorName = $"{existingInstructor.FirstName} {existingInstructor.LastName}";
            return course;

        }

        public async Task<Instructor> CreateProfile(string email, string biography, string firstName, string Lastname, string profilePicture)
        {
            var existing = await _instructorRepository.GetInstructor(x => x.Email == email);
            if (existing != null)  throw new DomainException("You already have a profile" , 409);
            var instructor = new Instructor
            {
                Biography = biography,
                Email = email,
                FirstName = firstName,
                LastName = Lastname,
                ProfilePicture = profilePicture,
            };
            instructor.CreateDetails(email, DateTime.UtcNow);
            var createProfile = _instructorRepository.Create(instructor);
           if (await _instructorRepository.Save() > 0)
           {
                return instructor;
           } 
           return null;
        }

        public async Task<Instructor> EditProfile(string email, string? biography, string? firstName, string? lastName)
        {
            var instructorProfile = await _instructorRepository.GetInstructor(x => x.Email == email);
            if (!string.IsNullOrEmpty(biography))
            {
                instructorProfile.Biography = biography;
            }

            if (!string.IsNullOrEmpty(firstName))
            {
                instructorProfile.FirstName = firstName;
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                instructorProfile.LastName = lastName;
            }

            // instructorProfile.ModifyDetails(email, DateTime.UtcNow);
            _instructorRepository.Update(instructorProfile);
            return instructorProfile;
        }

        public async Task<Instructor> EditProfilePicture(string email, string profilePicture)
        {
            var instructorProfile = await _instructorRepository.GetInstructor(x => x.Email == email);
            instructorProfile.ProfilePicture = profilePicture;
            // instructorProfile.ModifyDetails(email, DateTime.UtcNow);
            _instructorRepository.Update(instructorProfile);
            return instructorProfile;
        }

        public async Task<Instructor> GetProfile(string email)
        {
            var instructor = await _instructorRepository.GetInstructor(x => x.Email == email) ?? throw new DomainException("Instructor not found",404);
            return instructor;
        }
    }
}