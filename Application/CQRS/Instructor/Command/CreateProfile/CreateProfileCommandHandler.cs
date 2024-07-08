using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.CQRS.Instructor.Command.UpdateProfile
{
    public class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand, BaseResponse<InstructorDto>>
    {
        private readonly IInstructorManager _instructorManager;
        private readonly ICurrentUser _currentUser;
        private readonly IFileRepository _fileRespository;
        public CreateProfileCommandHandler(IInstructorManager instructorManager, ICurrentUser currentUser, IFileRepository fileRespository)
        {
            _instructorManager = instructorManager;
            _currentUser = currentUser;
            _fileRespository = fileRespository;
        }
        public async Task<BaseResponse<InstructorDto>> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentException("Fields cannot be null");
            }
            var email ="otufaleesther@gmail.com";// _currentUser.GetLoggedInUserEmail();
            var uploadedPicture = await _fileRespository.UploadFileAsync(request.Model.ProfilePicture);
            var createdProfile = await _instructorManager.CreateProfile(email, request.Model.Biography, request.Model.FirstName, request.Model.LastName, uploadedPicture);
            if (createdProfile == null)
            {
                return new BaseResponse<InstructorDto>
                {
                    Status = false,
                    Message = "Not Created",
                    Data = null
                };
            }
            return new BaseResponse<InstructorDto>
            {
                Status = true,
                Message = "Successful",
                Data = new InstructorDto
                {
                    Biography = createdProfile.Biography,
                    Email = createdProfile.Email,
                    FirstName = createdProfile.FirstName,
                    LastName = createdProfile.LastName,
                    ProfilePicture = createdProfile.ProfilePicture
                }
            };

        }
    }
}