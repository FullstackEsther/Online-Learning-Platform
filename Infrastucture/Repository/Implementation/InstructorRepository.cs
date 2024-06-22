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
    public class InstructorRepository : BaseRepository<Instructor> , IInstructorRepository
    {
        public InstructorRepository(ApplicationContext applicationContext)
        {
           _applicationContext = applicationContext; 
        }

        public void Delete(Instructor instructor)
        {
            _applicationContext.Instructors.Remove(instructor);
        }

        public async Task<IEnumerable<Instructor>> GetAllInstructors()
        {
            return await _applicationContext.Instructors.Include(x => x.Courses).ToListAsync();
        }

        public async Task<Instructor?> GetInstructor(Expression<Func<Instructor, bool>> predicate)
        {
            return await _applicationContext.Instructors
            .Include(x => x.Courses)
            .FirstOrDefaultAsync(predicate);
        }
    }
}