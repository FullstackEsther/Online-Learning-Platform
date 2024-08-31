using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using Domain.Entities;
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
            var course = await _courseManager.GetCourseByIdAsync(request.CourseId);

            if (course == null)
            {
                return new BaseResponse<CourseDto>
                {
                    Status = false,
                    Message = "Course doesn't exist"
                };
            }

            var courseDto = new CourseDto
            {
                Id = course.Id,
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
                Price = course.Price,
                NumberOfLessons = course.CalculateNumberOfLessons(),
                Modules = course.Modules?.Select(x => new ModuleDto
                {
                    CourseId = course.Id,
                    Id = x.Id,
                    Title = x.Title,
                    Totaltime = x.TotalTime,
                    Lessons = x.Lessons?.Select(l => new LessonDto
                    {
                         Id = l.Id,
                        Article = l.Article,
                        File = l.File,
                        ModuleId = l.ModuleId,
                        Topic = l.Topic,
                        TotalMinutes = l.TotalMinutes
                    }).ToList() ?? new List<LessonDto>(),
                    Quiz = x.Quiz == null ? null : new QuizDto
                    {
                         Id = x.Quiz.Id,
                        Duration = x.Quiz.Duration,
                        ModuleId = x.Quiz.ModuleId,
                        Questions = x.Quiz.Questions?.Select(q => new QuestionDto
                        {
                             Id = q.Id,
                            QuestionText = q.QuestionText,
                            QuizId = q.QuizId,
                            QuestionType = q.QuestionType,
                            questionOptions = q.Options?.Select(o => new QuestionOptionDto
                            {
                                Option = o.Text,
                                 IsCorrect = o.IsCorrect
                            }).ToList() ?? new List<QuestionOptionDto>()
                        }).ToList() ?? new List<QuestionDto>()
                    }
                }).ToList() ?? new List<ModuleDto>()
            };

            return new BaseResponse<CourseDto>
            {
                Status = true,
                Message = "Successful",
                Data = courseDto
            };
        }
    }
}