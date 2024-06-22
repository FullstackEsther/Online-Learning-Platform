using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.CQRS.Course.Command.DeleteCourseModule
{
    public record DeleteCourseModuleCommand(Guid CourseId, Guid ModuleId) :IRequest;
}