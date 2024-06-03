using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.RepositoryInterfaces
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<Role> Get(Expression<Func<Role, bool>> predicate);
        Task<IEnumerable<Role>> GetAll();
        void Delete(Role  role);
    }
}