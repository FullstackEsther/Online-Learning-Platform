using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using MediatR;

namespace Application.CQRS.Course.Query.GetCourseByInstructor
{
    public class GetCoursesByInstructorQueryHandler : IRequestHandler<GetCoursesByInstructorQuery, BaseResponse<IEnumerable<CourseDto>>>
    {
        private readonly ICourseManager _courseManager;

        public GetCoursesByInstructorQueryHandler(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }
        public async Task<BaseResponse<IEnumerable<CourseDto>>> Handle(GetCoursesByInstructorQuery request, CancellationToken cancellationToken)
        {
            var check = await _courseManager.GetAllCoursesByInstructorAsync(request.InstructorId);
            var courses = check.Any() ? check : throw new ArgumentException("There are no Courses fromthis Instructor");
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
            }).ToList();
            return new BaseResponse<IEnumerable<CourseDto>>
            {
                Status = true,
                Data = courseDtos,
                Message = "Successful"
            };
        }
    }
}