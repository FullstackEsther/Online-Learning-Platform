using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using MediatR;

namespace Application.CQRS.Course.Query.GetVerifiedCourses
{
    public class GetVerifiedCoursesQueryHandler : IRequestHandler<GetVerifiedCoursesQuery, BaseResponse<IEnumerable<CourseDto>>>
    {
        private readonly ICourseManager _courseManager;

        public GetVerifiedCoursesQueryHandler(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }
        public async Task<BaseResponse<IEnumerable<CourseDto>>> Handle(GetVerifiedCoursesQuery request, CancellationToken cancellationToken)
        {
            var check = await _courseManager.GetAllVerifiedCoursesAsync();
            var courses = check.Any() ? check : throw new ArgumentException("There are no verified courses");
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
                NumberOfLessons= course.CalculateNumberOfLessons(),
                 Price = course.Price
            }).ToList();
            return new BaseResponse<IEnumerable<CourseDto>>
            {
                 Data = courseDtos,
                  Status = true,
                   Message = "Successful"
            };
        }
    }
}