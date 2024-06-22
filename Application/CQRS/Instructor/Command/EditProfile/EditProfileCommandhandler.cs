using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using Domain.RepositoryInterfaces;
using Infrastucture.Repository.Implementation;
using MediatR;
using Microsoft.AspNetCore.Internal;

namespace Application.CQRS.Instructor.Command.EditProfile
{
    public class EditProfileCommandhandler : IRequestHandler<EditProfileCommand, BaseResponse<InstructorDto>>
    {
        private readonly IInstructorManager _instructorManager;
        private readonly ICurrentUser _currentUser;
        private readonly IInstructorRepository _instructorRepository;

        public EditProfileCommandhandler(IInstructorManager instructorManager, ICurrentUser currentUser, IInstructorRepository instructorRepository)
        {
            _instructorManager = instructorManager;
            _currentUser = currentUser;
            _instructorRepository = instructorRepository;
        }
        public async Task<BaseResponse<InstructorDto>> Handle(EditProfileCommand request, CancellationToken cancellationToken)
        {
            var email = "otufaleesther@gmail.com";   // _currentUser.GetLoggedInUserEmail();
            var editedProfile = await _instructorManager.EditProfile(email, request.Model.Biography, request.Model.FirstName, request.Model.LastName, request.Model.ProfilePicture);
            await _instructorRepository.Save();
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