using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.CQRS.Student.Command.EditProfile
{
    public class EditStudentProfileCommandHandler : IRequestHandler<EditStudentProfileCommand, BaseResponse<StudentDto>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICurrentUser _currentUser;

        public EditStudentProfileCommandHandler(IStudentRepository studentRepository, ICurrentUser currentUser)
        {
            _studentRepository = studentRepository;
            _currentUser = currentUser;
        }
        public async Task<BaseResponse<StudentDto>> Handle(EditStudentProfileCommand request, CancellationToken cancellationToken)
        {
            var email = "otufeesther@gmail.com"; //_currentUser.GetLoggedInUserEmail();
            var student = await _studentRepository.Get(x => x.Email == email) ?? throw new ArgumentException("Student doesn't exist");
            student.Biography = request.Model.Biography;
            student.FirstName = request.Model.FirstName;
            student.LastName = request.Model.LastName;
            student.ModifyDetails(email, DateTime.UtcNow);
            _studentRepository.Update(student);
            if (await _studentRepository.Save() > 0)
            {
                return new BaseResponse<StudentDto>
                {
                    Status = true,
                    Message = "Successfully Updated",
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