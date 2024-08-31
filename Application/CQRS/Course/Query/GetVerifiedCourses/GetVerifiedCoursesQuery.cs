using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.CQRS.Course.Query.GetVerifiedCourses
{
    public record GetVerifiedCoursesQuery() : IRequest<BaseResponse<IEnumerable<CourseDto>>>;
}