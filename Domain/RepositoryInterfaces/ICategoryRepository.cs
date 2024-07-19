using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.RepositoryInterfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<Category> Get(Expression<Func<Category, bool>> predicate); 
        Task<IEnumerable<Category>>  GetAllCategories();
        bool Exist(Expression<Func<Category, bool>> predicate);
        void Delete(Category category);
        Task<IEnumerable<Category>> GetAllCategories(Expression<Func<Category, bool>> predicate);
    }
}