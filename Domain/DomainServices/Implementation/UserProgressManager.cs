using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Domain.DomainServices.Interface;
using Domain.Entities;
using Domain.RepositoryInterfaces;

namespace Domain.DomainServices.Implementation
{
    public class UserProgressManager : IUserProgressManager
    {
        private readonly IUserProgressRepository _userProgressRepository;
        private readonly ICourseRepository _courseRepository;

        public UserProgressManager(IUserProgressRepository userProgressRepository, ICourseRepository courseRepository)
        {
            _userProgressRepository = userProgressRepository;
            _courseRepository = courseRepository;
        }
        public async Task<UserProgress> CreateUserProgress(string email, Guid lessonId, Guid courseId)
        {
            var course = await _courseRepository.GetCourse(x => x.Id == courseId) ?? throw new ArgumentException("Course doesnot exist");
            var lesson = course.Modules
            .SelectMany(module => module.Lessons)
            .FirstOrDefault(lesson => lesson.Id == lessonId) ?? throw new ArgumentException("Lesson doesn't exist");
            var userProgress = new UserProgress(email, courseId, lessonId);
            await _userProgressRepository.Create(userProgress);
            if (await _courseRepository.Save() > 0) return userProgress;
            return null;
        }

        public async Task<UserProgress> UpdateUserProgress(string email, Guid lessonId, Guid courseId)
        {
            var userProgress = await _userProgressRepository.Get(x => x.CourseId == courseId && x.LessonId == lessonId && x.UserEmail == email) ?? throw new ArgumentException("user progress doesnot esxist");
            userProgress.MarkAsCompleted();
            _userProgressRepository.Update(userProgress);
            await _userProgressRepository.Save();
            return userProgress;
        }
    }
}