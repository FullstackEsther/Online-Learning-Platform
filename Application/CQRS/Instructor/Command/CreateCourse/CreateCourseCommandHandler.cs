using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using Domain.RepositoryInterfaces;
using Infrastucture.Repository.Implementation;
using MediatR;

namespace Application.CQRS.Instructor.Command.CreateCourse
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, BaseResponse<CourseDto>>
    {
        private readonly IInstructorManager _instructorManager;
        private readonly ICurrentUser _currentUser;
        private readonly IInstructorRepository _instructorRepository;

        public CreateCourseCommandHandler(IInstructorManager instructorManager, ICurrentUser currentUser, IInstructorRepository instructorRepository)
        {
            _instructorManager = instructorManager;
            _currentUser = currentUser;
            _instructorRepository = instructorRepository;
        }
        public async Task<BaseResponse<CourseDto>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var email = "otufalesther@gmail.com";// _currentUser.GetLoggedInUserEmail(); //
            var course = await _instructorManager.CreateCourse(request.Model.Title, request.Model.Level, request.Model.CategoryId, request.Model.CourseCode, request.Model.CourseStatus, request.Model.WhatToLearn, request.Model.DisplayPicture, request.Model.ProfilePicture, request.Model.FirstName, request.Model.LastName, request.Model.Biography, email);
            await _instructorRepository.Save();
            if (course == null)
            {
                return new BaseResponse<CourseDto>
                {
                    Data = null,
                    Message = "Course not created",
                    Status = false
                };
            }
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
                    WhatToLearn = course.WhatToLearn,
                    Title = course.Title
                }
            };
        }
    }
}