using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.CQRS.Course.Query.GetCourseByCategory
{
    public record GetCoursesByCategoryQuery(Guid CategoryId): IRequest<BaseResponse<IEnumerable<CourseDto>>>;
}