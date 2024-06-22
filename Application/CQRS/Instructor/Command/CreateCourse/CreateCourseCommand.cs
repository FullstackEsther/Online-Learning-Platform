using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.CQRS.Instructor.Command.CreateCourse
{
    public record CreateCourseCommand(CourseRequestModel Model) :IRequest<BaseResponse<CourseDto>>;
}