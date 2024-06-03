using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.RepositoryInterfaces
{
    public interface IResultRepository : IBaseRepository<Result>
    {
        Task<Result> GetResult(Expression<Func<Result, bool>> predicate);
        Task<IEnumerable<Result>> GetAllResults();
        Task<IEnumerable<Result>> GetAllResults(Expression<Func<Result, bool>> predicate);
        void Delete(Result result);
    }
}