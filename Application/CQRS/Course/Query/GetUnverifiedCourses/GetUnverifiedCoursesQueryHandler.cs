using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using MediatR;

namespace Application.CQRS.Course.Query.GetUnverifiedCourses
{
    public class GetUnverifiedCoursesQueryHandler : IRequestHandler<GetUnverifiedCoursesQuery, BaseResponse<IEnumerable<CourseDto>>>
    {
        private readonly ICourseManager _courseManager;

        public GetUnverifiedCoursesQueryHandler(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }
        public async Task<BaseResponse<IEnumerable<CourseDto>>> Handle(GetUnverifiedCoursesQuery request, CancellationToken cancellationToken)
        {
            var check = await _courseManager.GetAllUnVerifiedCoursesAsync();
            var courses = check.Any() ?check : throw new ArgumentException("There are no unverified Courses Available");
            var courseDtos = courses.Select(course => new CourseDto
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
                NumberOfLessons= course.CalculateNumberOfLessons()
            }).ToList();
            return new BaseResponse<IEnumerable<CourseDto>>
            {
                Data = courseDtos,
                Message = "Successful",
                Status = true
            };
        }
    }
}