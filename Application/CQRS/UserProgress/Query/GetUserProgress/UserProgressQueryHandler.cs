using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.CQRS.UserProgress.Query.GetUserProgress
{
    public class UserProgressQueryHandler : IRequestHandler<UserProgressQuery, BaseResponse<UserProgressDto>>
    {
        private readonly ICurrentUser _currentUser;
        private readonly IUserProgressManager _userProgressManager;

        public UserProgressQueryHandler(ICurrentUser currentUser, IUserProgressManager userProgressManager)
        {
            _currentUser = currentUser;
            _userProgressManager = userProgressManager;
        }
        public async Task<BaseResponse<UserProgressDto>> Handle(UserProgressQuery request, CancellationToken cancellationToken)
        {
            var email = _currentUser.GetLoggedInUserEmail();
            var getUserProgress = await _userProgressManager.CalculateUserProgress(email, request.CourseId);
            return new BaseResponse<UserProgressDto>
            {
                Status = true,
                Message = "Successful",
                Data = new UserProgressDto
                {
                    NumberOfCompletedLessons = getUserProgress
                }
            };

        }
    }
}