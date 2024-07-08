using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.CQRS.Course.Command.DeleteQuestion
{
    public record DeleteQuizQuestionCommand(Guid ModuleId, Guid QuestionId):IRequest;
}