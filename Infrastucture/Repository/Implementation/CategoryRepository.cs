using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Infrastucture.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Repository.Implementation
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public  Task<Category> Get(Expression<Func<Category, bool>> predicate)
        {
            var category = _applicationContext.Categories
            .SingleOrDefaultAsync(predicate);
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var categories = await _applicationContext.Categories.ToListAsync();
            return categories;
        }
    }
}
