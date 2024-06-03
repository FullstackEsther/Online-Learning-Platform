using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.RepositoryInterfaces
{
    public interface IEnrollmentRepository : IBaseRepository<Enrollment>
    {
        Task<Enrollment> GetEnrollment(Expression<Func<Enrollment, bool>> predicate);
       Task<IEnumerable<Enrollment>> GetAllEnrollments(Expression<Func<Enrollment, bool>> predicate);
    }
}