using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.RepositoryInterfaces
{
    public interface IInstructorRepository: IBaseRepository<Instructor>
    {
        Task<Instructor> GetInstructor(Expression<Func<Instructor, bool>> predicate);
        Task<IEnumerable<Instructor>> GetAllInstructors();
        void Delete(Instructor instructor); 
    }
}