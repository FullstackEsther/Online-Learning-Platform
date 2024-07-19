using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DomainServices.Interface;
using MediatR;

namespace Application.CQRS.UserProgress.AddProgress
{
    public class AddProgressCommandHandler : IRequestHandler<AddProgressCommand, bool>
    {
        private readonly IUserProgressManager _userProgressManager;
        private readonly ICurrentUser _currentUser;

        public AddProgressCommandHandler(IUserProgressManager userProgressManager, ICurrentUser currentUser)
        {
            _userProgressManager = userProgressManager;
            _currentUser = currentUser;
        }
        public async Task<bool> Handle(AddProgressCommand request, CancellationToken cancellationToken)
        {
            var email = "otufeesther@gmail.com"; //_currentUser.GetLoggedInUserEmail();
           var user = await  _userProgressManager.CreateUserProgress(email, request.LessonId,request.CourseId) ?? throw new ArgumentException("Userprogress Not Created");
           return true;
        }
    }
}