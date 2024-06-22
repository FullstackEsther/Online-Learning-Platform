using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.CQRS.Course.Command.UpdateCourseModule
{
    public record UpdateCourseModuleCommand(Guid CourseId, Guid ModuleId, string Title) : IRequest;
}