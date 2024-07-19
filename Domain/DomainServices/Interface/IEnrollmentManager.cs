using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.DomainServices.Interface
{
    public interface IEnrollmentManager
    {
        Task<Enrollment> EnrollStudent(string reference,Guid courseId, string email);
    }
}