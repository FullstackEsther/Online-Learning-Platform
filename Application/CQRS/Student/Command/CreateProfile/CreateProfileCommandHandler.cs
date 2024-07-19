using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.CQRS.Student.Command.CreateProfile
{
    public class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand, BaseResponse<StudentDto>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICurrentUser _currentUser;
        private readonly IFileRepository _fileRepository;

        public CreateProfileCommandHandler(IStudentRepository studentRepository, ICurrentUser currentUser, IFileRepository fileRepository)
        {
            _studentRepository = studentRepository;
            _currentUser = currentUser;
            _fileRepository = fileRepository;
        }
        public async Task<BaseResponse<StudentDto>> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
        {
            var email =  "otufeesther@gmail.com"; //_currentUser.GetLoggedInUserEmail();
            var profilePictureUrl = string.Empty;
            if (request.Model.ProfilePicture != null)
            {
                profilePictureUrl = await _fileRepository.UploadFileAsync(request.Model.ProfilePicture);
            }
            var student = new Domain.Entities.Student()
            {
                Email = email,
                Biography = request.Model.Biography,
                FirstName = request.Model.FirstName,
                LastName = request.Model.LastName,
                ProfilePicture = profilePictureUrl,
            };
            student.CreateDetails(email, DateTime.UtcNow);
            await _studentRepository.Create(student);
            if (await _studentRepository.Save() > 0)
            {
                return new BaseResponse<StudentDto>
                {
                    Status = true,
                    Message = "Successful",
                    Data = new StudentDto
                    {
                        Email = student.Email,
                        Biography = student.Biography,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        ProfilePicture = student.ProfilePicture
                    }
                };
            }
            return new BaseResponse<StudentDto>
            {
                Data = null,
                Message = "Not Created",
                Status = false
            };
        }
    }
}