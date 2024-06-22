using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using Infrastucture.Repository.Implementation;
using MediatR;

namespace Application.CQRS.Instructor.Query
{
    public class GetInstructorProfileQueryHandler : IRequestHandler<GetInstructorProfileQuery, BaseResponse<ProfileDto>>
    {
        private readonly IInstructorManager _instructoManager;
        private readonly ICurrentUser _currentUser;
        public GetInstructorProfileQueryHandler(IInstructorManager instructoManager, ICurrentUser currentUser)
        {
            this._currentUser = currentUser;
            _instructoManager = instructoManager;

        }
        public async Task<BaseResponse<ProfileDto>> Handle(GetInstructorProfileQuery request, CancellationToken cancellationToken)
        {
            var profile = await _instructoManager.GetProfile("otufaleesther@gmail.com");
            if (profile == null)
            {
                return new BaseResponse<ProfileDto>
                {
                    Status = false,
                    Message = "Not Updated",
                    Data = null
                };
            }
            return new BaseResponse<ProfileDto>
            {
                Status = true,
                Message = "Successful",
                Data = new ProfileDto
                {
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    Biography = profile.Biography,
                    ProfilePicture = profile.ProfilePicture
                }
            };
        }
    }
}