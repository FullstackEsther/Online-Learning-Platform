using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using Domain.Enum;
using MediatR;

namespace Application.CQRS.Course.Query.GetCourse
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, BaseResponse<CourseDto>>
    {
        private readonly ICourseManager _courseManager;

        public GetCourseByIdQueryHandler(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }
        public async Task<BaseResponse<CourseDto>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseManager.GetCourseByIdAsync(request.CourseId) ?? throw new ArgumentException("Course doesn't exist");
            return new BaseResponse<CourseDto>
            {
                Status = true,
                Message = "Successful",
                Data = new CourseDto
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
                    Modules = course.Modules.Select(x => new ModuleDto
                    {
                        CourseId = course.Id,
                        Title = x.Title,
                        Totaltime = x.TotalTime,
                        Lessons = x.Lessons.Select(x => new LessonDto
                        {
                            Article = x.Article,
                            File = x.File,
                            ModuleId = x.ModuleId,
                            Topic = x.Topic,
                            TotalMinutes = x.TotalMinutes
                        }).ToList(),
                        Quiz = new QuizDto
                        {
                            Duration = x.Quiz.Duration,
                            ModuleId = x.Quiz.ModuleId,
                            Questions = x.Quiz.Questions.Select(x => new QuestionDto
                            {
                                QuestionText = x.QuestionText,
                                QuizId = x.QuizId,
                                QuestionType = x.QuestionType,
                                questionOptions = x.Options.Select(x => new QuestionOptionDto
                                {
                                    option = x.Text
                                }).ToList()
                            }).ToList()
                        }

                    }).ToList()
                }
            };
        }
    }
}