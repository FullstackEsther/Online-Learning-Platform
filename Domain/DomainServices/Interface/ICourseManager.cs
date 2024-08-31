using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain.Shared.Enum;
using Domain.Entities;
using Domain.Enum;
using Domain.ValueObjects;

namespace Domain.DomainServices.Interface
{
    public interface ICourseManager
    {
        public Task<Course> CreateCourse(string title, Level level, Guid categoryId, string courseCode,CourseStatus courseStatus,string whatToLearn,string displayPicture,string email, double? price);
        public Task<Course> VerifyCourse(Guid courseId);
        public Task<Module> AddModuleToCourse(Guid courseId,string title);
        public Task<Quiz> AddQuizToModule(Guid moduleId,double duration);
        public Task<Question> AddOptionToQuestion(Guid questionId, bool isCorrectoption, string optionText,Guid moduleId) ;
        public Task<Question> AddQuestionToQuiz(Guid quizId,Guid moduleId, QuestionType questionType, string questionText);
        // public Task<ICollection<QuestionAnswer>> AddQuestionAnswerToQuiz(Guid quizId, List<string> selectedOptions, Guid questionId);
        public Task<Result> AddResultToQuiz(Guid quizId, ICollection<QuestionAnswer> answers, string email);
        Task<Lesson> AddLessonToModule(Guid moduleId,string topic,string file,double totalMinutes,string? article);
        public  Task<bool> UpdateCourse(string title,string courseCode,double? price, string whatToLearn, CourseStatus courseStatus,Level level,Guid categoryId,  Guid courseId);
        public  Task DeleteCourse(Guid courseId);
        public Task<bool> UpdateCourseModule(Guid CourseId , string title, Guid moduleId);
        public Task<Course> UpdateDisplaypicture(Guid CourseId , string displaypictureUrl);
        public Task<bool> UpdateModuleLesson(string topic, Guid moduleId, double totalMinutes, string? article, Guid lessonId);
        public Task<bool> UpdateLessonFile( Guid moduleId, string fileUrl, Guid lessonId);
        public Task<bool> UpdateQuizQuestion(string questionText, Guid moduleId, QuestionType questionType, Guid questionId);
        public Task DeleteCourseModule(Guid CourseId, Guid moduleId);
        public Task DeleteModuleLesson(Guid moduleId, Guid  lessonId);
        public Task DeleteModuleQuiz(Guid moduleId);
        public Task DeleteQuizQuestion(Guid moduleId,Guid QuestionId);
        public Task RemoveQuestionOption(Guid moduleId,Guid QuestionId,string text);
        public Task<Course> GetCourseByIdAsync(Guid courseId);
        public Task<IEnumerable<Course>> GetAllCoursesAsync();
        public Task<IEnumerable<Course>> GetAllVerifiedCoursesAsync();
        public Task<IEnumerable<Course>> GetAllUnVerifiedCoursesAsync();
        public Task<IEnumerable<Course>> GetAllCoursesByInstructorAsync(Guid instructorId);
        public Task<IEnumerable<Course>> GetCoursesByCategoryAsync(Guid categoryId );
    }
}