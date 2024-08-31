using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DomainServices.Interface;
using MediatR;

namespace Application.CQRS.Course.Command.VerifyCourse
{
    public record VerifyCourseCommandHandler : IRequestHandler<VerifyCourseCommand, bool>
    {
        private readonly ICourseManager _courseManager;

        public VerifyCourseCommandHandler(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }
        public async Task<bool> Handle(VerifyCourseCommand request, CancellationToken cancellationToken)
        {
            var response = await _courseManager.VerifyCourse(request.CourseId);
            if (response!= null) return true;
            return false;
        }
    }
}