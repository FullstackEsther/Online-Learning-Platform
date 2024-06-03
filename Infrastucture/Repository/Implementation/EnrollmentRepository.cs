using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Infrastucture.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Repository.Implementation
{
    public class EnrollmentRepository : BaseRepository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<IEnumerable<Enrollment>> GetAllEnrollments(Expression<Func<Enrollment, bool>> predicate)
        {
            var enrollments = await _applicationContext.Enrollments.Where(predicate).ToListAsync();
            return enrollments;
        }

        public async Task<Enrollment> GetEnrollment(Expression<Func<Enrollment, bool>> predicate)
        {
            return await _applicationContext.Enrollments.FirstOrDefaultAsync(predicate);
        }
    }
}