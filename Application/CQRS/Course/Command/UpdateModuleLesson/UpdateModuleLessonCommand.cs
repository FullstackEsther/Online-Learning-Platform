using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.CQRS.Course.Command.UpdateModuleLesson
{
    public record UpdateModuleLessonCommand(string Topic, string? Article, Guid ModuleId, Guid LessonId, double TotalMinutes) : IRequest<bool>;
 
}