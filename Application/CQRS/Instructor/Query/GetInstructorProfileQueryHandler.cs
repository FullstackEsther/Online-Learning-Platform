using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using CloudinaryDotNet;
using Domain.DomainServices.Interface;
using Infrastucture.Repository.Implementation;
using MediatR;

namespace Application.CQRS.Instructor.Query
{
    public class GetInstructorProfileQueryHandler : IRequestHandler<GetInstructorProfileQuery, BaseResponse<InstructorDto>>
    {
        private readonly IInstructorManager _instructoManager;
        private readonly ICurrentUser _currentUser;
        private readonly Cloudinary _cloudinary;
        public GetInstructorProfileQueryHandler(IInstructorManager instructoManager, ICurrentUser currentUser, Cloudinary cloudinary)
        {
            _currentUser = currentUser;
            _instructoManager = instructoManager;
            _cloudinary = cloudinary;
        }
        public async Task<BaseResponse<InstructorDto>> Handle(GetInstructorProfileQuery request, CancellationToken cancellationToken)
        {
            var profile = await _instructoManager.GetProfile(_currentUser.GetLoggedInUserEmail());
            if (profile == null)
            {
                return new BaseResponse<InstructorDto>
                {
                    Status = false,
                    Message = "Not Updated",
                    Data = null
                };
            }
            return new BaseResponse<InstructorDto>
            {
                Status = true,
                Message = "Successful",
                Data = new InstructorDto
                {
                    Id = profile.Id,
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    Biography = profile.Biography,
                    ProfilePicture = profile.ProfilePicture
                }
            };
        }
    }
}