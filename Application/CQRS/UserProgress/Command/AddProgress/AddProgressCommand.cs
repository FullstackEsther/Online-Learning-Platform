using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.CQRS.UserProgress.AddProgress
{
    public record AddProgressCommand(Guid LessonId,Guid CourseId) :IRequest<bool>;
}