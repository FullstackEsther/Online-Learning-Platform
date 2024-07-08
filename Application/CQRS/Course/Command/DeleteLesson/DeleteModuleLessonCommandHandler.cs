using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DomainServices.Interface;
using MediatR;

namespace Application.CQRS.Course.Command.DeleteLesson
{
    public class DeleteModuleLessonCommandHandler : IRequestHandler<DeleteModuleLessonCommand>
    {
        private readonly ICourseManager _courseManager;

        public DeleteModuleLessonCommandHandler(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }
        public async Task Handle(DeleteModuleLessonCommand request, CancellationToken cancellationToken)
        {
           await _courseManager.DeleteModuleLesson(request.ModuleId,request.LessonId);
        }
    }
}