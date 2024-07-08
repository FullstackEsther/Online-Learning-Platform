using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using MediatR;

namespace Application.CQRS.Course.Query.GetAllCourses
{
    public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, BaseResponse<IReadOnlyList<CourseDto>>>
    {
        private readonly ICourseManager _courseManager;

        public GetAllCoursesQueryHandler(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }
        public async Task<BaseResponse<IReadOnlyList<CourseDto>>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _courseManager.GetAllCoursesAsync() ?? throw new ArgumentException("No Courses Found");
            var courseDtos = courses.Select(course => new CourseDto
            {
                CategoryId = course.CategoryId,
                CourseCode = course.CourseCode,
                CourseStatus = course.CourseStatus,
                DisplayPicture = course.DisplayPicture,
                InstructorId = course.InstructorId,
                InstructorName = course.InstructorName,
                IsVerified = course.IsVerified,
                Level = course.Level,
                Title = course.Title,
                TotalTime = course.TotalTime,
                WhatToLearn = course.WhatToLearn,
                Modules = course.Modules.Select(module => new ModuleDto
                {
                    CourseId = course.Id,
                    Title = module.Title,
                    Totaltime = module.TotalTime,
                    Lessons = module.Lessons.Select(lesson => new LessonDto
                    {
                        Article = lesson.Article,
                        File = lesson.File,
                        ModuleId = lesson.ModuleId,
                        Topic = lesson.Topic,
                        TotalMinutes = lesson.TotalMinutes
                    }).ToList(),
                    Quiz = new QuizDto
                    {
                        Duration = module.Quiz.Duration,
                        ModuleId = module.Quiz.ModuleId,
                        Questions = module.Quiz.Questions.Select(question => new QuestionDto
                        {
                            QuestionText = question.QuestionText,
                            QuizId = question.QuizId,
                            QuestionType = question.QuestionType,
                            questionOptions = question.Options.Select(option => new QuestionOptionDto
                            {
                                option = option.Text
                            }).ToList()
                        }).ToList()
                    }
                }).ToList()
            }).ToList();

            return new BaseResponse<IReadOnlyList<CourseDto>>
            {
                Status = true,
                Message = "Successful",
                Data = courseDtos.AsReadOnly()
            };
        }
    }
}