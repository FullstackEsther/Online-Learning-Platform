using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.RepositoryInterfaces
{
    public interface IUserProgressRepository : IBaseRepository<UserProgress>
    {
        bool Exist(Expression<Func<UserProgress, bool>> predicate);
        Task<UserProgress> Get(Expression<Func<UserProgress, bool>> predicate); 
        Task<IEnumerable<UserProgress>> GetAll();
    }
}