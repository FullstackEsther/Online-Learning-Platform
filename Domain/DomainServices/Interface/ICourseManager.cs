using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain.Shared.Enum;
using Domain.Entities;
using Domain.Enum;

namespace Domain.DomainServices.Interface
{
    public interface ICourseManager
    {
        public Task<Course> CreateCourse(string title, Level level, Guid categoryId, string courseCode,CourseStatus courseStatus,string whatToLearn,string displayPicture,string email);
        public Task<Module> AddModuleToCourse(Guid courseId,string title);
        Task<Lesson> AddLessonToModule(Guid moduleId);
        // Task<bool> DeleteCourse(string? courseCode , Guid? courseId);
        public  Task<bool> UpdateCourse(string title,string courseCode,double? price,string displayPicture, string whatToLearn, CourseStatus courseStatus,Level level,Guid categoryId,  Guid courseId);
        public  Task DeleteCourse(Guid courseId);
        public Task<bool> UpdateCourseModule(Guid CourseId , string title, Guid moduleId);
        public Task DeleteCourseModule(Guid CourseId, Guid moduleId);

    }
}