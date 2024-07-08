using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.CQRS.Course.Command.DeleteLesson
{
    public record DeleteModuleLessonCommand(Guid ModuleId, Guid LessonId) : IRequest;
}