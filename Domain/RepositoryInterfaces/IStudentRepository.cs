using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.RepositoryInterfaces
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Task<Student> Get(Guid id);
        Task<Student> Get(Expression<Func<Student, bool>> predicate);
        Task<IEnumerable<Student>> GetAll(Expression<Func<Student, bool>> predicate);
        void Delete(Student student);
    }
}