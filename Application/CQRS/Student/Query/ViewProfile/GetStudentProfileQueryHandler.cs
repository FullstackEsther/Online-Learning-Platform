using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.CQRS.Student.Query.ViewProfile
{
    public class GetStudentProfileQueryHandler : IRequestHandler<GetStudentProfileQuery, BaseResponse<StudentDto>>
    {
        private readonly ICurrentUser _currentUser;
        private readonly IStudentRepository _studentRepository;

        public GetStudentProfileQueryHandler(ICurrentUser currentUser, IStudentRepository studentRepository)
        {
            _currentUser = currentUser;
            _studentRepository = studentRepository;
        }
        public async Task<BaseResponse<StudentDto>> Handle(GetStudentProfileQuery request, CancellationToken cancellationToken)
        {
            var email =_currentUser.GetLoggedInUserEmail();
            var student = await _studentRepository.Get(x => x.Email == email) ?? throw new ArgumentException("Student Not Found");
            return new BaseResponse<StudentDto>
            {
                Status = true,
                Message = "Successful",
                Data = new StudentDto
                {
                     Id = student.Id,
                    Biography = student.Biography,
                    Email = student.Email,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    ProfilePicture = student.ProfilePicture
                }
            };
        }
    }
}