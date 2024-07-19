using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.CQRS.Course.Command.UpdateLessonFile
{
    public record UpdateLessonFileCommand(Guid ModuleId,Guid LessonId, IFormFile File): IRequest<bool>;
}