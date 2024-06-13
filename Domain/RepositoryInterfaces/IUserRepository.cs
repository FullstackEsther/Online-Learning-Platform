using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.RepositoryInterfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        bool Exist(Expression<Func<User, bool>> predicate);
        Task<User> Get(Expression<Func<User, bool>> predicate); 
        Task<IEnumerable<User>> GetAll(); 
        void Delete(User user); 
    }
}