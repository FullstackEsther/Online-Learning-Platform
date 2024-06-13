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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void Delete(User user)
        {
            _applicationContext.Users.Remove(user);
        }

        public bool Exist(Expression<Func<User, bool>> predicate)
        {
            return _applicationContext.Users.Any(predicate);
        }

        public async Task<User?> Get(Expression<Func<User, bool>> predicate)
        {
            return await _applicationContext.Users
            .Include(x => x.UserRoles).ThenInclude(x => x.Role)
            .FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _applicationContext.Users
            .Include(x => x.UserRoles).ThenInclude(x => x.Role)
            .ToListAsync();
        }
    }
}