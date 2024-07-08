using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.CQRS.Course.Command.DeleteOption
{
    public record DeleteQuestionOptionCommand(Guid ModuleId, Guid QuestionId, string Text) : IRequest;
}