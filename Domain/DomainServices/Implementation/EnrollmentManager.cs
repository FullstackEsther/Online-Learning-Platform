using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain.Shared.Exception;
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
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentManager(IPaymentManager paymentManager, IStudentRepository studentRepository, ICourseRepository courseRepository,IEnrollmentRepository enrollmentRepository)
        {
            _paymentManager = paymentManager;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _enrollmentRepository = enrollmentRepository;
        }
        public async Task<Enrollment> EnrollStudent(string? reference, Guid courseId, string email)
        { 
            var payment = new Payment();
            if (reference != null)
            {
               payment = await _paymentManager.VerifyPayment(reference);
            }
            var student = await _studentRepository.Get(x => x.Email == email) ?? throw new DomainException("Student doesnot exist",404);
            var course = await _courseRepository.GetCourse(x => x.Id == courseId) ?? throw new DomainException("Course doesnot exist",404);
            if (student.Enrollments.Any(e => e.CourseId == courseId))
            {
                throw new DomainException("Student already Enrolled");
            }
            if (course.CourseStatus == Enum.CourseStatus.Free)
            {
                var enrollment = new Enrollment
                {
                    CourseId = courseId,
                    StudentId = student.Id,
                };
                await _enrollmentRepository.Create(enrollment);
                await _enrollmentRepository.Save();
                return enrollment;
            }
            if (payment != null && student != null)
            {
                var enrollment = new Enrollment
                {
                    CourseId = courseId,
                    PaymentId = payment.Id,
                    StudentId = student.Id,
                };
                await _enrollmentRepository.Create(enrollment);
                await _enrollmentRepository.Save();
                return enrollment;
            }
            return null;
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollments(string email)
        {
            var student = await  _studentRepository.Get(x => x.Email == email);
            if (student == null)
            {
                return null;
            }
           var enrollments = await  _enrollmentRepository.GetAllEnrollments(x => x.StudentId == student.Id);
           return enrollments;
        }
    }
}