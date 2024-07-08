using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DomainServices.Interface;
using MediatR;

namespace Application.CQRS.Course.Command.DeleteQuiz
{
    public class DeleteModuleQuizCommandHandler : IRequestHandler<DeleteModuleQuizCommand>
    {
        private readonly ICourseManager _courseManager;

        public DeleteModuleQuizCommandHandler(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }
        public async Task Handle(DeleteModuleQuizCommand request, CancellationToken cancellationToken)
        {
           await  _courseManager.DeleteModuleQuiz(request.ModuleId);
        }
    }
}