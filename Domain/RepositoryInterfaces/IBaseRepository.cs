using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> Create(T entity);
        T Update(T entity);
        Task<int> Save();
    }
}