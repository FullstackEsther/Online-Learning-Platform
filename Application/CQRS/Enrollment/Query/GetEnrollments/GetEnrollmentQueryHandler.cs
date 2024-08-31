using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using MediatR;

namespace Application.CQRS.Enrollment.Query.GetEnrollments
{
    public record GetEnrollmentQueryHandler : IRequestHandler<GetEnrollmentQuery, BaseResponse<IEnumerable<EnrollmentDto>>>
    {
        private readonly IEnrollmentManager _enrollmentManager;
        private readonly ICurrentUser _currentUser;

        public GetEnrollmentQueryHandler(IEnrollmentManager enrollmentManager, ICurrentUser currentUser)
        {
            _enrollmentManager = enrollmentManager;
            _currentUser = currentUser;
        }
        public async Task<BaseResponse<IEnumerable<EnrollmentDto>>> Handle(GetEnrollmentQuery request, CancellationToken cancellationToken)
        {
            var email = _currentUser.GetLoggedInUserEmail();
            var enrollments = await _enrollmentManager.GetEnrollments(email);
            if (enrollments.Any())
            {
                return new BaseResponse<IEnumerable<EnrollmentDto>>
                {
                    Message = "Successful",
                    Status = true,
                    Data = enrollments.Select(x => new EnrollmentDto
                    {
                        CourseId = x.CourseId,
                        PaymentId = x.PaymentId,
                        StudentId = x.StudentId,
                        CourseDto = new CourseDto
                        {
                            Title = x.Course.Title,
                            DisplayPicture = x.Course.DisplayPicture
                        }
                    }).ToList()

                };
            }
            return new BaseResponse<IEnumerable<EnrollmentDto>>
            {
                Data = null,
                Message = "No Enrrolments Yet",
                Status = false
            };

        }
    }
}