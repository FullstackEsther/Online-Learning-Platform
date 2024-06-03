using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Infrastucture.Context;

namespace Infrastucture.Repository.Implementation
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseClass
    {
        protected ApplicationContext _applicationContext;
        public async Task<T> Create(T entity)
        {
            await _applicationContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<int> Save()
        {
           return await _applicationContext.SaveChangesAsync();
        }

        public T Update(T entity)
        {
           _applicationContext.Update(entity);
           return entity;
        }
    }
    
}