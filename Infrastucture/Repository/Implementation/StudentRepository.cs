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
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void Delete(Student student)
        {
            _applicationContext.Students.Remove(student);
        }

        public async Task<Student> Get(Guid id)
        {
            return await _applicationContext.Students
             .Include(x => x.Enrollments)
             .Include(x => x.Results)
             .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Student> Get(Expression<Func<Student, bool>> predicate)
        {
            return await  _applicationContext.Students.Include(x => x.Enrollments)
            .Include(x => x.Results).FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Student>> GetAll(Expression<Func<Student, bool>> predicate)
        {
            return await _applicationContext.Students.Include(x => x.Enrollments)
            .Include(x => x.Results).Where(predicate).ToListAsync();
        }
    }
}