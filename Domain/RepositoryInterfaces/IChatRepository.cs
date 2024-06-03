using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities.Chat;

namespace Domain.RepositoryInterfaces
{
    public interface IChatRepository : IBaseRepository<ChatRoom>
    {
        Task<ChatRoom> Get(Expression<Func<ChatRoom, bool>> predicate); 
    }
}