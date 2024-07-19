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
            var check = await _courseManager.GetAllCoursesAsync();
            var courses = check.Any() ? check : throw new ArgumentException("No Courses Found");
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
                WhatToLearn = course.WhatToLearn
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