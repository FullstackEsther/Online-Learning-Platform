using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DomainServices.Interface;
using MediatR;

namespace Application.CQRS.Course.Command.DeleteQuestion
{
    public class DeleteQuizQuestionCommandHandler : IRequestHandler<DeleteQuizQuestionCommand>
    {
        private readonly ICourseManager _courseManager;

        public DeleteQuizQuestionCommandHandler(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }
        public async Task Handle(DeleteQuizQuestionCommand request, CancellationToken cancellationToken)
        {
             await _courseManager.DeleteQuizQuestion(request.ModuleId,request.QuestionId);
        }
    }
}