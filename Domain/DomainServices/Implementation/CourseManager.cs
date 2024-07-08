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
using Domain.ValueObjects;
using Microsoft.AspNetCore.Internal;

namespace Domain.DomainServices.Implementation
{
    public class CourseManager : ICourseManager
    {
        private readonly ICourseRepository _courseRepository;

        public CourseManager(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<Lesson> AddLessonToModule(Guid moduleId, string topic, string file, double totalMinutes, string? article)
        {
            var course = await _courseRepository.GetCourse(course => course.Modules.Any(m => m.Id == moduleId)) ?? throw new ArgumentException("Course doesn't exist");
            var module = course.Modules.FirstOrDefault(x => x.Id == moduleId) ?? throw new ArgumentException("module doesn't exist");
            var lesson = new Lesson(topic, file, module.Id, totalMinutes, article);
            lesson.CreateDetails(course.InstructorName, DateTime.UtcNow);
            module.AddLessons(lesson);
            _courseRepository.Update(course);
            var unitofWork = await _courseRepository.Save();
            if (unitofWork > 0)
            {
                return lesson;
            }
            return null;
        }

        public async Task<Module> AddModuleToCourse(Guid courseId, string title)
        {
            var getCourse = await _courseRepository.GetCourse(x => x.Id == courseId) ?? throw new ArgumentException("Course doesnot exist");
            var module = new Module(title, courseId);
            module.CreateDetails(getCourse.InstructorName, DateTime.UtcNow);
            getCourse.AddModule(module);
            _courseRepository.Update(getCourse);
            var unitofWork = await _courseRepository.Save();
            if (unitofWork <= 0)
            {
                return null;
            }
            return module;
        }

        public async Task<Question> AddOptionToQuestion(Guid questionId, bool isCorrectoption, string optionText, Guid moduleId)
        {
            var course = await _courseRepository.GetCourse(course => course.Modules.Any(m => m.Id == moduleId)) ?? throw new ArgumentException("Course doesn't exist");
            var module = course.Modules.FirstOrDefault(x => x.Id == moduleId) ?? throw new ArgumentException("module doesn't exist");
            var question = module.Quiz.Questions.FirstOrDefault(x => x.Id == questionId) ?? throw new ArgumentException("Question doesn't exist");
            var option = new QuestionOption(optionText, isCorrectoption, questionId);
            question.AddOption(option);
            _courseRepository.Update(course);
            if (await _courseRepository.Save() > 0) return question;
            return null;
        }

        public async Task<Question> AddQuestionToQuiz(Guid quizId, Guid moduleId, QuestionType questionType, string questionText)
        {
            var course = await _courseRepository.GetCourse(course => course.Modules.Any(m => m.Id == moduleId)) ?? throw new ArgumentException("Course doesn't exist");
            var module = course.Modules.FirstOrDefault(x => x.Id == moduleId) ?? throw new ArgumentException("module doesn't exist");
            var quiz = module.Quiz.Id == quizId ? module.Quiz : throw new ArgumentException("quiz doesn't exit");
            var question = new Question(questionText, quizId, questionType);
            quiz.AddQuestion(question);
            _courseRepository.Update(course);
            if (await _courseRepository.Save() > 0) return question;
            return null;
        }

        public async Task<Quiz> AddQuizToModule(Guid moduleId, double duration)
        {
            var course = await _courseRepository.GetCourse(course => course.Modules.Any(m => m.Id == moduleId)) ?? throw new ArgumentException("Course doesn't exist");
            var module = course.Modules.FirstOrDefault(x => x.Id == moduleId) ?? throw new ArgumentException("module doesn't exist");
            var quiz = new Quiz(duration, moduleId);
            quiz.CreateDetails(course.InstructorName, DateTime.UtcNow);
            module.SetQuiz(quiz);
            _courseRepository.Update(course);
            if (await _courseRepository.Save() > 0) return quiz;
            return null;
        }

        public async Task<Course> CreateCourse(string title, Level level, Guid categoryId, string courseCode, CourseStatus courseStatus, string whatToLearn, string displayPicture, string email)
        {
            var checkCourse = _courseRepository.Exist(x => x.CourseCode == courseCode);
            if (checkCourse) throw new ArgumentException("Course Code already exist");
            var course = new Course(title, level, categoryId, courseCode, courseStatus, whatToLearn, displayPicture);
            course.CreateDetails(email, DateTime.UtcNow);
            return await _courseRepository.Create(course);
        }

        public async Task DeleteCourse(Guid courseId)
        {
            var course = await _courseRepository.GetCourse(x => x.Id == courseId) ?? throw new ArgumentException("Course does not exist");
            _courseRepository.Delete(course);
            await _courseRepository.Save();
        }

        public async Task DeleteCourseModule(Guid courseId, Guid moduleId)
        {
            var getCourse = await _courseRepository.GetCourse(x => x.Id == courseId) ?? throw new ArgumentException("Course doesnot exist");
            var existingModule = getCourse.Modules.FirstOrDefault(x => x.Id == moduleId) ?? throw new ArgumentException("Module doesnot exist");
            getCourse.RemoveModule(existingModule);
            await _courseRepository.Save();
        }

        public async Task DeleteModuleLesson(Guid moduleId, Guid lessonId)
        {
            var course = await _courseRepository.GetCourse(course => course.Modules.Any(m => m.Id == moduleId)) ?? throw new ArgumentException("Course doesn't exist");
            var module = course.Modules.FirstOrDefault(x => x.Id == moduleId) ?? throw new ArgumentException("module doesn't exist");
            module.RemoveLesson(lessonId);
            await _courseRepository.Save();
        }

        public async Task DeleteModuleQuiz(Guid moduleId)
        {
            var course = await _courseRepository.GetCourse(course => course.Modules.Any(m => m.Id == moduleId)) ?? throw new ArgumentException("Course doesn't exist");
            var module = course.Modules.FirstOrDefault(x => x.Id == moduleId) ?? throw new ArgumentException("module doesn't exist");
            module.RemoveQuiz();
            await _courseRepository.Save();
        }

        public async Task DeleteQuizQuestion(Guid moduleId, Guid questionId)
        {
            var course = await _courseRepository.GetCourse(course => course.Modules.Any(m => m.Id == moduleId)) ?? throw new ArgumentException("Course doesn't exist");
            var module = course.Modules.FirstOrDefault(x => x.Id == moduleId) ?? throw new ArgumentException("module doesn't exist");
            module.Quiz.DeleteQuestion(questionId);
            await _courseRepository.Save();
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _courseRepository.GetAllCourse();
        }

        public async Task<IEnumerable<Course>> GetAllCoursesByInstructorAsync(Guid instructorId)
        {
           return await _courseRepository.GetAllCourses(x => x.InstructorId == instructorId);
        }

        public async Task<IEnumerable<Course>> GetAllVerifiedCoursesAsync()
        {
            return await _courseRepository.GetAllCourses(x => x.IsVerified == true);
        }

        public async Task<Course> GetCourseByIdAsync(Guid courseId)
        {
            return await _courseRepository.GetCourse(x => x.Id == courseId);
        }

        public async Task<IEnumerable<Course>> GetCoursesByCategoryAsync(Guid categoryId)
        {
          return await _courseRepository.GetAllCourses(x => x.CategoryId == categoryId);
        }

        public async Task RemoveQuestionOption(Guid moduleId, Guid questionId, string text)
        {
            var course = await _courseRepository.GetCourse(course => course.Modules.Any(m => m.Id == moduleId)) ?? throw new ArgumentException("Course doesn't exist");
            var module = course.Modules.FirstOrDefault(x => x.Id == moduleId) ?? throw new ArgumentException("module doesn't exist");
            var question = module.Quiz.Questions.FirstOrDefault(x => x.Id == questionId) ?? throw new ArgumentException("question doesn't exist");
            var option = question.Options.FirstOrDefault(x => x.Text == text);
            question.RemoveOption(option);
        }

        public async Task<bool> UpdateCourse(string title, string courseCode, double? price, string displayPicture, string whatToLearn, CourseStatus courseStatus, Level level, Guid categoryId, Guid courseId)
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
            existingCourse.ModifyDetails(existingCourse.InstructorName, DateTime.UtcNow);
            var updatedCourse = _courseRepository.Update(existingCourse);
            await _courseRepository.Save();
            if (updatedCourse == null) return false;
            return true;
        }

        public async Task<bool> UpdateCourseModule(Guid courseId, string title, Guid moduleId)
        {
            var getCourse = await _courseRepository.GetCourse(x => x.Id == courseId) ?? throw new ArgumentException("Course doesnot exist");
            var existingModule = getCourse.Modules.FirstOrDefault(x => x.Id == moduleId) ?? throw new ArgumentException("Module doesnot exist");
            existingModule.Title = title;
            existingModule.ModifyDetails(getCourse.InstructorName, DateTime.UtcNow);
            getCourse.UpdateModule(existingModule);
            if (await _courseRepository.Save() > 0) return true;
            return false;
        }

        public async Task<bool> UpdateModuleLesson(string topic, Guid moduleId, string file, double totalMinutes, string? article, Guid lessonId)
        {
            var course = await _courseRepository.GetCourse(course => course.Modules.Any(m => m.Id == moduleId)) ?? throw new ArgumentException("Course doesn't exist");
            var module = course.Modules.FirstOrDefault(x => x.Id == moduleId) ?? throw new ArgumentException("module doesn't exist");
            var existingLesson = module.Lessons.FirstOrDefault(x => x.Id == lessonId) ?? throw new ArgumentException("Lesson Not Found");
            existingLesson.Article = article;
            existingLesson.File = file;
            existingLesson.Topic = topic;
            existingLesson.TotalMinutes = totalMinutes;
            existingLesson.ModifyDetails(course.InstructorName, DateTime.UtcNow);
            _courseRepository.Update(course);
            if (await _courseRepository.Save() > 0) return true;
            return false;
        }
    }
}