using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.CQRS.Course.Command.VerifyCourse
{
    public record VerifyCourseCommand(Guid CourseId) : IRequest<bool>;
}