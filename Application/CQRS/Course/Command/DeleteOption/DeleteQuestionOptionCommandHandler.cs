using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DomainServices.Interface;
using MediatR;

namespace Application.CQRS.Course.Command.DeleteOption
{
    public class DeleteQuestionOptionCommandHandler : IRequestHandler<DeleteQuestionOptionCommand>
    {
        private readonly ICourseManager _courseManager;

        public DeleteQuestionOptionCommandHandler(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }
        public async Task Handle(DeleteQuestionOptionCommand request, CancellationToken cancellationToken)
        {
            await _courseManager.RemoveQuestionOption(request.ModuleId, request.QuestionId, request.Text);
        }
    }
}