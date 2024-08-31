using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.CQRS.UserProgress.UpdateProgress
{
    public record UpdateProgressCommand(Guid LeessonId, Guid CourseId) : IRequest<bool>; 
}