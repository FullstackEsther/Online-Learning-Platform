using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DomainServices.Interface;
using MediatR;

namespace Application.CQRS.Course.Command.UpdateCourseModule
{
    public class UpdateCourseModuleCommandHandler : IRequestHandler<UpdateCourseModuleCommand>
    {
        private readonly ICourseManager _courseManager;

        public UpdateCourseModuleCommandHandler(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }
        public async Task Handle(UpdateCourseModuleCommand request, CancellationToken cancellationToken)
        {
            await _courseManager.UpdateCourseModule(request.CourseId,request.Title, request.ModuleId);
        }
    }
}