using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DomainServices.Interface;
using MediatR;

namespace Application.CQRS.Course.Command.DeleteCourse
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand>
    {
        private readonly ICourseManager _courseManager;

        public DeleteCourseCommandHandler(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }
        public async Task Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
           await _courseManager.DeleteCourse(request.CourseId);
        }
    }
}