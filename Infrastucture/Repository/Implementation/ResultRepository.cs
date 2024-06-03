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
    public class ResultRepository : BaseRepository<Result>, IResultRepository
    {
        public ResultRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void Delete(Result result)
        {
            _applicationContext.Results.Remove(result); 
        }

        public async Task<IEnumerable<Result>> GetAllResults()
        {
            return await _applicationContext.Results.ToListAsync();
        }

        public async Task<IEnumerable<Result>> GetAllResults(Expression<Func<Result, bool>> predicate)
        {
             return await _applicationContext.Results.Where(predicate).ToListAsync();
        }

        public async Task<Result> GetResult(Expression<Func<Result, bool>> predicate)
        {
            return await _applicationContext.Results.FirstOrDefaultAsync(predicate);
        }
    }
}