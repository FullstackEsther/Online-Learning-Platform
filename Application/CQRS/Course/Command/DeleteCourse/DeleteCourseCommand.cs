using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.CQRS.Course.Command.DeleteCourse
{
    public record DeleteCourseCommand(Guid CourseId): IRequest;
}