using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DomainServices.Interface;
using MediatR;

namespace Application.CQRS.UserProgress.UpdateProgress
{
    public class UpdateProgressCommandHandler : IRequestHandler<UpdateProgressCommand, bool>
    {
        private readonly IUserProgressManager _userProgressManager;
        private readonly ICurrentUser _currentUser;

        public UpdateProgressCommandHandler(IUserProgressManager userProgressManager, ICurrentUser currentUser)
        {
            _userProgressManager = userProgressManager;
            _currentUser = currentUser;
        }


        public async Task<bool> Handle(UpdateProgressCommand request, CancellationToken cancellationToken)
        { 
            var email = "otufeesther@gmail.com"; //_currentUser.GetLoggedInUserEmail();
            var progress = await _userProgressManager.UpdateUserProgress(email, request.LeessonId, request.CourseId) ?? throw new ArgumentException("Progress not Updated");
            return true;
        }
    }
}