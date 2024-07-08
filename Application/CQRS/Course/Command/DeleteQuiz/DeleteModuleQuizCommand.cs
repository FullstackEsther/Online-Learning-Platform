using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.CQRS.Course.Command.DeleteQuiz
{
    public record DeleteModuleQuizCommand(Guid ModuleId) : IRequest;
   
}