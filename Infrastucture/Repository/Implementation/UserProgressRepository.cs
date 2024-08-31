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
    public class UserProgressRepository : BaseRepository<UserProgress>, IUserProgressRepository
    {
        public UserProgressRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public bool Exist(Expression<Func<UserProgress, bool>> predicate)
        {
            return _applicationContext.UserProgresses.Any(predicate);
        }

        public async Task<UserProgress?> Get(Expression<Func<UserProgress, bool>> predicate)
        {
            return await _applicationContext.UserProgresses
            .FirstOrDefaultAsync(predicate);
        }

        public async  Task<IEnumerable<UserProgress>> GetAll(Expression<Func<UserProgress, bool>> predicate)
        {
            return await _applicationContext.UserProgresses
            .Where(predicate)
            .ToListAsync();
        }
    }
}