using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CQRS.Instructor.Query;
using Application.DTO;
using MediatR;

namespace Application.CQRS.Course.Command
{
    public record UpdateCourseCommand(UpdateCourseRequestModel Model, Guid CourseId) : IRequest<bool>;
}