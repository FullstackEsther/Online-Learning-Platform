using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DomainServices.Interface;
using MediatR;

namespace Application.CQRS.Course.Command.DeleteCourseModule
{
    public class DeleteCourseModuleCommandHandler : IRequestHandler<DeleteCourseModuleCommand>
    {
        private readonly ICourseManager _courseManager;

        public DeleteCourseModuleCommandHandler(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }
        public async Task Handle(DeleteCourseModuleCommand request, CancellationToken cancellationToken)
        {
           await _courseManager.DeleteCourseModule(request.CourseId,request.ModuleId);
        }
    }
}