using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.CQRS.Instructor.Command.EditProfilePicture
{
    public record EditProfilePictureCommandHandler : IRequestHandler<EditProfilePictureCommand, BaseResponse<InstructorDto>>
    {
         private readonly IInstructorManager _instructorManager;
        private readonly ICurrentUser _currentUser;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IFileRepository _fileRepository;

        public EditProfilePictureCommandHandler(IInstructorManager instructorManager, ICurrentUser currentUser, IInstructorRepository instructorRepository, IFileRepository fileRepository)
        {
            _instructorManager = instructorManager;
            _currentUser = currentUser;
            _instructorRepository = instructorRepository;
            _fileRepository = fileRepository;
        }
        public async Task<BaseResponse<InstructorDto>> Handle(EditProfilePictureCommand request, CancellationToken cancellationToken)
        {
            var email =  _currentUser.GetLoggedInUserEmail();
            var newPicture =  await _fileRepository.UploadFileAsync(request.Model.ProfilePicture);
            var editedProfile = await _instructorManager.EditProfilePicture(email,newPicture);
             if (editedProfile == null)
            {
                return new BaseResponse<InstructorDto>
                {
                    Status = false,
                    Message = "Unsuccessful",
                    Data = null
                };
            }
            return new BaseResponse<InstructorDto>
            {
                Status = true,
                Message = "Successful",
                Data = new InstructorDto
                {
                    ProfilePicture = editedProfile.ProfilePicture,
                    FirstName = editedProfile.FirstName,
                    LastName = editedProfile.LastName,
                    Biography = editedProfile.Biography,
                    Email = email
                }
             };
    }
}
}