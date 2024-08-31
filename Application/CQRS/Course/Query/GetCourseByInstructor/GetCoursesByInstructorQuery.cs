using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.CQRS.Course.Query.GetCourseByInstructor
{
    public record GetCoursesByInstructorQuery(Guid InstructorId) : IRequest<BaseResponse<IEnumerable<CourseDto>>>;
}