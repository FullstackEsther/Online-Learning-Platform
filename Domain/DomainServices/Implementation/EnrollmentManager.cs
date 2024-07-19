using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DomainServices.Interface;
using Domain.Entities;
using Domain.RepositoryInterfaces;

namespace Domain.DomainServices.Implementation
{
    public class EnrollmentManager : IEnrollmentManager
    {
        private readonly IPaymentManager _paymentManager;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public EnrollmentManager(IPaymentManager paymentManager, IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _paymentManager = paymentManager;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }
        public async Task<Enrollment> EnrollStudent(string reference, Guid courseId, string email)
        {
            var student = await _studentRepository.Get(x => x.Email == email) ?? throw new ArgumentException("Student doesnot exist");
            var course = await _courseRepository.GetCourse(x => x.Id == courseId) ?? throw new ArgumentException("Course doesnot exist");
            if (student.Enrollments.Any(e => e.CourseId == courseId))
            {
                throw new ArgumentException("Student already Enrolled");
            }
            if (course.CourseStatus == Enum.CourseStatus.Free)
            {
                var enrollment = new Enrollment
                {
                    CourseId = courseId,
                    StudentId = student.Id,
                };
                return enrollment;
            }
            var payment = await _paymentManager.VerifyPayment(reference);
            if (payment != null && student != null)
            {
                var enrollment = new Enrollment
                {
                    CourseId = courseId,
                    PaymentId = payment.Id,
                    StudentId = student.Id,
                };
                return enrollment;
            }
            return null;
        }
    }
}