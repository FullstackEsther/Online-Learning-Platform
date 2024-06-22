using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Domain.Domain.Shared.Enum;
using Domain.DomainServices.Interface;
using Domain.Entities;
using Domain.Enum;
using Domain.RepositoryInterfaces;

namespace Domain.DomainServices.Implementation
{
    public class CourseManager : ICourseManager
    {
        private readonly ICourseRepository _courseRepository;

        public CourseManager(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public Task<Lesson> AddLessonToModule(Guid moduleId)
        {
            throw new NotImplementedException();
        }

        public async Task<Module> AddModuleToCourse(Guid courseId, string title)
        {
            var getCourse = await _courseRepository.GetCourse(x => x.Id == courseId) ?? throw new ArgumentException("Course doesnot exist");
            var module = new Module(title, courseId);
            module.CreateDetails(getCourse.InstructorName, DateTime.UtcNow);
            getCourse.AddModule(module);
            // getCourse.Modules.Add(module);
            _courseRepository.Update(getCourse);
            var unitofWork = await _courseRepository.Save();
            if (unitofWork <= 0 )
            {
                return null;
            }
            return module;
        }

        public async Task<Course> CreateCourse(string title, Level level, Guid categoryId, string courseCode, CourseStatus courseStatus, string whatToLearn, string displayPicture, string email)
        {
            var checkCourse = _courseRepository.Exist(x => x.CourseCode == courseCode);
            if (checkCourse) throw new ArgumentException("Course Code already exist");
            var course = new Course(title, level, categoryId, courseCode, courseStatus, whatToLearn, displayPicture);
            course.CreateDetails(email, DateTime.UtcNow);
            return await _courseRepository.Create(course);
        }

        // public async Task<bool> DeleteCourse(string? courseCode, Guid? courseId)
        // {
        //     var course = await _courseRepository.GetCourse(x => x.Id == courseId || x.CourseCode == courseCode) ?? throw new ArgumentException("Course not found");
        //     _courseRepository.Delete(course);
        //     return true;
        // }

        public async Task DeleteCourse(Guid courseId)
        {
            var course = await _courseRepository.GetCourse(x => x.Id == courseId) ?? throw new ArgumentException("Course does not exist");
            _courseRepository.Delete(course);
           await _courseRepository.Save();
        }

        public async Task DeleteCourseModule(Guid courseId, Guid moduleId)
        {
           var getCourse = await _courseRepository.GetCourse(x => x.Id == courseId) ?? throw new ArgumentException("Course doesnot exist");
           var existingModule = getCourse.Modules.FirstOrDefault(x => x.Id == moduleId) ?? throw new ArgumentException ("Module doesnot exist");
           getCourse.RemoveModule(existingModule);
           await _courseRepository.Save();
        }

        public async Task<bool> UpdateCourse(string title,string courseCode,double? price,string displayPicture, string whatToLearn, CourseStatus courseStatus,Level level,Guid categoryId,  Guid courseId)
        {
            var existingCourse = await _courseRepository.GetCourse(x => x.Id == courseId) ?? throw new ArgumentException("Course does not exist");
            existingCourse.Title = title;
            existingCourse.CourseCode = courseCode;
            existingCourse.Price = price;
            existingCourse.DisplayPicture = displayPicture;
            existingCourse.WhatToLearn = whatToLearn;
            existingCourse.Level = level;
            existingCourse.CourseStatus = courseStatus;
            existingCourse.CategoryId = categoryId;
           var updatedCourse = _courseRepository.Update(existingCourse);
           await _courseRepository.Save();
            if (updatedCourse == null) return false;
            return true;
        }

        public async Task<bool> UpdateCourseModule(Guid courseId, string title, Guid moduleId)
        {
            var getCourse = await _courseRepository.GetCourse(x => x.Id == courseId) ?? throw new ArgumentException("Course doesnot exist");
            var existingModule = getCourse.Modules.FirstOrDefault(x => x.Id == moduleId) ?? throw new ArgumentException ("Module doesnot exist");
            existingModule.Title = title;
            getCourse.UpdateModule(existingModule);
           if(await _courseRepository.Save() > 0) return true;
           return false;
        }
        
    }
}