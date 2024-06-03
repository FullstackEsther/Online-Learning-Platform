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
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void Delete(Role role)
        {
            _applicationContext.Roles.Remove(role);
        }

        public async Task<Role> Get(Expression<Func<Role, bool>> predicate)
        {
           return await _applicationContext.Roles.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await _applicationContext.Roles.ToListAsync();
        }
    }
}