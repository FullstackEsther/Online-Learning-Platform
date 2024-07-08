using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain.Shared.Enum;
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
        public async Task<Course> CreateCourse(string title, Level level, Guid categoryId, string courseCode, CourseStatus courseStatus, string whatToLearn, string displayPicture, string? profilePicture, string? firstName, string? lastName, string? biography, string? email)
        {
            var existingInstructor = await _instructorRepository.GetInstructor(x => x.Email == email);
            if (existingInstructor == null)
            {
                var instructor = new Instructor()
                {
                    Biography = biography,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    ProfilePicture = profilePicture
                };
                instructor.CreateDetails(email, DateTime.UtcNow);
                await _instructorRepository.Create(instructor);
                var course = await _courseManager.CreateCourse(title, level, categoryId, courseCode, courseStatus, whatToLearn, displayPicture, email);
                course.InstructorName = $"{firstName} {lastName}";
                course.InstructorId = instructor.Id;
                return course;
            }
            var subsequentCourse = await _courseManager.CreateCourse(title, level, categoryId, courseCode, courseStatus, whatToLearn, displayPicture, email);
            subsequentCourse.InstructorId = existingInstructor.Id;
            subsequentCourse.InstructorName = $"{existingInstructor.FirstName} {existingInstructor.LastName}";
            return subsequentCourse;

        }

        public async Task<Instructor> CreateProfile(string email, string biography, string firstName, string Lastname, string profilePicture)
        {
            var existing = _instructorRepository.GetInstructor(x => x.Email == email);
            if (existing != null)  throw new ArgumentException("You already have a profile");
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

        public async Task<Instructor> EditProfile(string email, string? biography, string? firstName, string? lastName, string? profilePicture)
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

            if (!string.IsNullOrEmpty(profilePicture))
            {
                instructorProfile.ProfilePicture = profilePicture;
            }

            instructorProfile.ModifyDetails(email, DateTime.UtcNow);
            _instructorRepository.Update(instructorProfile);
            return instructorProfile;
        }

        public async Task<Instructor> GetProfile(string email)
        {
            var instructor = await _instructorRepository.GetInstructor(x => x.Email == email) ?? throw new ArgumentException("Instructor not found");
            return instructor;
        }
    }
}