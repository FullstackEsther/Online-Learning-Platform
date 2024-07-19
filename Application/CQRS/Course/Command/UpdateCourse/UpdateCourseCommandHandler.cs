using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using MediatR;

namespace Application.CQRS.Course.Command
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, bool>
    {
        private readonly ICourseManager _courseManager;

        public UpdateCourseCommandHandler(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }
        public async Task<bool> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var update = await _courseManager.UpdateCourse(request.Model.Title, request.Model.CourseCode, request.Model.Price, request.Model.WhatToLearn, request.Model.CourseStatus, request.Model.Level, request.Model.CategoryId, request.CourseId);
            return update;
        }
    }
}