using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using MediatR;

namespace Application.CQRS.Enrollment.Command.Enroll
{
    public class StudentEnrollmentCommandHandler : IRequestHandler<StudentEnrollmentCommand, BaseResponse<EnrollmentDto>>
    {
        private readonly IEnrollmentManager _enrollmentManager;
        private readonly ICurrentUser _currentUser;

        public StudentEnrollmentCommandHandler(IEnrollmentManager enrollmentManager, ICurrentUser currentUser)
        {
            _enrollmentManager = enrollmentManager;
            _currentUser = currentUser;
        }
        public async Task<BaseResponse<EnrollmentDto>> Handle(StudentEnrollmentCommand request, CancellationToken cancellationToken)
        {
            var email = _currentUser.GetLoggedInUserEmail();
            var enroll = await _enrollmentManager.EnrollStudent(request.Reference, request.CourseId, email);
            if (enroll != null)
            {
                return new BaseResponse<EnrollmentDto>
                {
                    Status = true,
                    Message = "Successfully Enrolled",
                    Data = new EnrollmentDto
                    {
                        CourseId = enroll.CourseId,
                        PaymentId = enroll.PaymentId,
                        StudentId = enroll.StudentId
                    }
                };
            }
            return new BaseResponse<EnrollmentDto>
            {
                Data = null,
                Message = "not found",
                Status = false
            };

        }
    }
}