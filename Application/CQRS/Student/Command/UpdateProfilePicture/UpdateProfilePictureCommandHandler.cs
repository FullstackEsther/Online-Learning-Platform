using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.CQRS.Student.Command.UpdateProfilePicture
{
    public class UpdateProfilePictureCommandHandler : IRequestHandler<UpdateProfilePictureCommand, BaseResponse<StudentDto>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICurrentUser _currentUser;
        private readonly IFileRepository _fileRepository;

        public UpdateProfilePictureCommandHandler(IStudentRepository studentRepository, ICurrentUser currentUser, IFileRepository fileRepository)
        {
            _studentRepository = studentRepository;
            _currentUser = currentUser;
            _fileRepository = fileRepository;
        }
        public async Task<BaseResponse<StudentDto>> Handle(UpdateProfilePictureCommand request, CancellationToken cancellationToken)
        {
            var email = _currentUser.GetLoggedInUserEmail();//"otufeesther@gmail.com";
            var student = await _studentRepository.Get(x => x.Email == email) ?? throw new ArgumentException("Student doesn't exist");
            var profile = await _fileRepository.UploadFileAsync(request.File);
            student.ProfilePicture = profile;
            _studentRepository.Update(student);
            if (await _studentRepository.Save() > 0)
            {
                return new BaseResponse<StudentDto>
                {
                    Status = true,
                    Message = "Updated",
                    Data = new StudentDto
                    {
                        Biography = student.Biography,
                        Email = student.Email,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        ProfilePicture = student.ProfilePicture
                    }
                };
            }
            return new BaseResponse<StudentDto>
            {
                Data = null,
                Message = "Not Updated",
                Status = false
            };
        }
    }
}