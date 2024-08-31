using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Domain.Domain.Shared.Enum;
using Domain.Domain.Shared.Exception;
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
        private readonly IStudentRepository _studentRepository;

        public CourseManager(ICourseRepository courseRepository, IStudentRepository studentRepository)
        {
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
        }

        public async Task<Lesson> AddLessonToModule(Guid moduleId, string topic, string file, double totalMinutes, string? article)
        {
            var course = await _courseRepository.GetCourse(course => course.Modules.Any(m => m.Id == moduleId)) ?? throw new DomainException("Course doesn't exist",404);
            var module = course.Modules.FirstOrDefault(x => x.Id == moduleId) ?? throw new DomainException("module doesn't exist",404);
            var lesson = new Lesson(topic, file, module.Id, totalMinutes, article);
            lesson.CreateDetails(course.InstructorName, DateTime.UtcNow);
            module.AddLessons(lesson);
            await _courseRepository.AddLesson(lesson);
            var unitofWork = await _courseRepository.Save();
            if (unitofWork > 0)
            {
                return lesson;
            }
            return null;
        }

        public async Task<Module> AddModuleToCourse(Guid courseId, string title)
        {
            var getCourse = await _courseRepository.GetCourse(x => x.Id == courseId) ?? throw new DomainException("Course doesnot exist",404);
            var module = new Module(title, courseId);
            module.CreateDetails(getCourse.InstructorName, DateTime.UtcNow);
            getCourse.AddModule(module);
            await _courseRepository.AddModule(module);
            var unitofWork = await _courseRepository.Save();
            if (unitofWork <= 0)
            {
                return null;
            }
            return module;
        }

        public async Task<Question> AddOptionToQuestion(Guid questionId, bool isCorrectoption, string optionText, Guid moduleId)
        {
            var course = await _courseRepository.GetCourse(course => course.Modules.Any(m => m.Id == moduleId)) ?? throw new DomainException("Course doesn't exist",404);
            var module = course.Modules.FirstOrDefault(x => x.Id == moduleId) ?? throw new DomainException("module doesn't exist",404);
            var question = module.Quiz.Questions.FirstOrDefault(x => x.Id == questionId) ?? throw new DomainException("Question doesn't exist",404);
            var option = new QuestionOption(optionText, isCorrectoption, questionId);
            question.AddOption(option);
            _courseRepository.UpdateQuestion(question);
            var unitofWork = await _courseRepository.Save();
            if (unitofWork > 0) return question;
            return null;
        }

        public async Task<Question> AddQuestionToQuiz(Guid quizId, Guid moduleId, QuestionType questionType, string questionText)
        {
            var course = await _courseRepository.GetCourse(course => course.Modules.Any(m => m.Id == moduleId)) ?? throw new DomainException("Course doesn't exist",404);
            var module = course.Modules.FirstOrDefault(x => x.Id == moduleId) ?? throw new DomainException("module doesn't exist",404);
            var quiz = module.Quiz.Id == quizId ? module.Quiz : throw new DomainException("quiz doesn't exit",404);
            var question = new Question(questionText, quizId, questionType);
            quiz.AddQuestion(question);
            await _courseRepository.AddQuestion(question);
            if (await _courseRepository.Save() > 0) return question;
            return null;
        }

        public async Task<Quiz> AddQuizToModule(Guid moduleId, double duration)
        {
            var course = await _courseRepository.GetCourse(course => course.Modules.Any(m => m.Id == moduleId)) ?? throw new DomainException("Course doesn't exist",404);
            var module = course.Modules.FirstOrDefault(x => x.Id == moduleId) ?? throw new DomainException("module doesn't exist",404);
            var quiz = new Quiz(duration, moduleId)
            {
                 Module = module,
            };
            quiz.CreateDetails(course.InstructorName, DateTime.UtcNow);
            module.SetQuiz(quiz);
            await _courseRepository.AddQuiz(quiz);
            if (await _courseRepository.Save() > 0) return quiz;
            return null;
        }

        public async Task<Result> AddResultToQuiz(Guid quizId, ICollection<QuestionAnswer> answers, string email)
        {
            var student = await _studentRepository.Get(x => x.Email == email);
            var course = await _courseRepository.GetCourse(course => course.Modules.Any(x => x.Quiz.Id == quizId)) ?? throw new DomainException("Course doesn't exist",404);
            var module = course.Modules.FirstOrDefault(x => x.Quiz.Id == quizId) ?? throw new DomainException("module doesn't exist",404);
            var result = new Result(quizId,student.Id,answers)
            {
                 Quiz = module.Quiz,
            };
            result.CalculateScore();
            result.CheckScore();
            module.Quiz.AddResult(result);
            await _courseRepository.AddResult(result);
            if (await _courseRepository.Save() > 0) return result;
            return null;
        }

        public async Task<Course> CreateCourse(string title, Level level, Guid categoryId, string courseCode, CourseStatus courseStatus, string whatToLearn, string displayPicture, string email, double? price)
        {
            var checkCourse = _courseRepository.Exist(x => x.CourseCode == courseCode);
            if (checkCourse) throw new DomainException("Course Code already exist",404);
            var course = new Course(title, level, categoryId, courseCode, courseStatus, whatToLearn, displayPicture)
            {
                Price = price
            };
            course.CreateDetails(email, DateTime.UtcNow);
            return await _courseRepository.Create(course);
        }

        public async Task DeleteCourse(Guid courseId)
        {
            var course = await _courseRepository.GetCourse(x => x.Id == courseId) ?? throw new DomainException("Course does not exist",404);
            _courseRepository.Delete(course);
            await _courseRepository.Save();
        }

        public async Task DeleteCourseModule(Guid courseId, Guid moduleId)
        {
            var getCourse = await _courseRepository.GetCourse(x => x.Id == courseId) ?? throw new DomainException("Course doesnot exist",404);
            var existingModule = getCourse.Modules.FirstOrDefault(x => x.Id == moduleId) ?? throw new DomainException("Module doesnot exist",404);
            getCourse.RemoveModule(existingModule);
            await _courseRepository.Save();
        }

        public async Task DeleteModuleLesson(Guid moduleId, Guid lessonId)
        {
            var course = await _courseRepository.GetCourse(course => course.Modules.Any(m => m.Id == moduleId)) ?? throw new DomainException("Course doesn't exist",404);
            var module = course.Modules.FirstOrDefault(x => x.Id == moduleId) ?? throw new DomainException("module doesn't exist",404);
            module.RemoveLesson(lessonId);
            await _courseRepository.Save();
        }

        public async Task DeleteModuleQuiz(Guid moduleId)
        {
            var course = await _courseRepository.GetCourse(course => course.Modules.Any(m => m.Id == moduleId)) ?? throw new DomainException("Course doesn't exist",404);
            var module = course.Modules.FirstOrDefault(x => x.Id == moduleId) ?? throw new DomainException("module doesn't exist",404);
            module.RemoveQuiz();
            await _courseRepository.Save();
        }

        public async Task DeleteQuizQuestion(Guid moduleId, Guid questionId)
        {
            var course = await _courseRepository.GetCourse(course => course.Modules.Any(m => m.Id == moduleId)) ?? throw new DomainException("Course doesn't exist",404);
            var module = course.Modules.FirstOrDefault(x => x.Id == moduleId) ?? throw new DomainException("module doesn't exist",404);
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

        public async Task<IEnumerable<Course>> GetAllUnVerifiedCoursesAsync()
        {
            return await _courseRepository.GetAllCourses(x => x.IsVerified == false);
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
            var course = await _courseRepository.GetCourse(course => course.Modules.Any(m => m.Id == moduleId)) ?? throw new DomainException("Course doesn't exist",404);
            var module = course.Modules.FirstOrDefault(x => x.Id == moduleId) ?? throw new DomainException("module doesn't exist",404);
            var question = module.Quiz.Questions.FirstOrDefault(x => x.Id == questionId) ?? throw new DomainException("question doesn't exist",404);
            var option = question.Options.FirstOrDefault(x => x.Text == text) ?? throw new DomainException("Option doesnot exist",404);
            question.RemoveOption(option);
            _courseRepository.UpdateQuestion(question);
            await _courseRepository.Save();
        }

        public async Task<bool> UpdateCourse(string title, string courseCode, double? price, string whatToLearn, CourseStatus courseStatus, Level level, Guid categoryId, Guid courseId)
        {
            var existingCourse = await _courseRepository.GetCourse(x => x.Id == courseId) ?? throw new DomainException("Course does not exist",404);
            existingCourse.Title = title;
            existingCourse.CourseCode = courseCode;
            existingCourse.Price = price;
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
            var getCourse = await _courseRepository.GetCourse(x => x.Id == courseId) ?? throw new DomainException("Course doesnot exist",404);
            var existingModule = getCourse.Modules.FirstOrDefault(x => x.Id == moduleId) ?? throw new DomainException("Module doesnot exist",404);
            existingModule.Title = title;
            existingModule.ModifyDetails(getCourse.InstructorName, DateTime.UtcNow);
            getCourse.UpdateModule(existingModule);
            if (await _courseRepository.Save() > 0) return true;
            return false;
        }

        public async Task<Course> UpdateDisplaypicture(Guid courseId, string displaypictureUrl)
        {

            var existingCourse = await _courseRepository.GetCourse(x => x.Id == courseId) ?? throw new DomainException("Course does not exist",404);
            existingCourse.DisplayPicture = displaypictureUrl;
            _courseRepository.Update(existingCourse);
            if (await _courseRepository.Save() > 0) return existingCourse;
            return null;
        }

        public async Task<bool> UpdateLessonFile(Guid moduleId, string fileUrl, Guid lessonId)
        {
            var course = await _courseRepository.GetCourse(course => course.Modules.Any(m => m.Id == moduleId)) ?? throw new DomainException("Course doesn't exist",404);
            var module = course.Modules.FirstOrDefault(x => x.Id == moduleId) ?? throw new DomainException("module doesn't exist",404);
            var existingLesson = module.Lessons.FirstOrDefault(x => x.Id == lessonId) ?? throw new DomainException("Lesson Not Found",404);
            existingLesson.File = fileUrl;
            existingLesson.ModifyDetails(course.InstructorName, DateTime.UtcNow);
            _courseRepository.Update(course);
            if (await _courseRepository.Save() > 0) return true;
            return false;
        }

        public async Task<bool> UpdateModuleLesson(string topic, Guid moduleId, double totalMinutes, string? article, Guid lessonId)
        {
            var course = await _courseRepository.GetCourse(course => course.Modules.Any(m => m.Id == moduleId)) ?? throw new DomainException("Course doesn't exist",404);
            var module = course.Modules.FirstOrDefault(x => x.Id == moduleId) ?? throw new DomainException("module doesn't exist",404);
            var existingLesson = module.Lessons.FirstOrDefault(x => x.Id == lessonId) ?? throw new DomainException("Lesson Not Found",404);
            existingLesson.Article = article;
            existingLesson.Topic = topic;
            existingLesson.TotalMinutes = totalMinutes;
            existingLesson.ModifyDetails(course.InstructorName, DateTime.UtcNow);
            _courseRepository.Update(course);
            if (await _courseRepository.Save() > 0) return true;
            return false;
        }

        public async Task<bool> UpdateQuizQuestion(string questionText, Guid moduleId, QuestionType questionType, Guid questionId)
        {
            var course = await _courseRepository.GetCourse(course => course.Modules.Any(m => m.Id == moduleId)) ?? throw new DomainException("Course doesn't exist",404);
            var module = course.Modules.FirstOrDefault(x => x.Id == moduleId) ?? throw new DomainException("module doesn't exist",404);
            var question = module.Quiz.Questions.FirstOrDefault(x => x.Id == questionId) ?? throw new DomainException("question doesn't exist",404);
            question.QuestionText = questionText;
            question.QuestionType = questionType;
            module.Quiz.UpdateQuestion(question);
            _courseRepository.Update(course);
            if (await _courseRepository.Save() > 0) return true;
            return false;
        }

        public async Task<Course> VerifyCourse(Guid courseId)
        {
            var course = await _courseRepository.GetCourse(course => course.Id == courseId) ?? throw new DomainException("Course doesn't exist",404);
            course.VerifyCourse();
            _courseRepository.Update(course);
            if (await _courseRepository.Save() > 0) return course;
            return null;
        }
    }
}