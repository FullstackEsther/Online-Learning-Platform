using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities.Chat;
using Domain.RepositoryInterfaces;
using Infrastucture.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Repository.Implementation
{
    public class ChatRepository : BaseRepository<ChatRoom>, IChatRepository
    {
        public ChatRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<ChatRoom> Get(Expression<Func<ChatRoom, bool>> predicate)
        {
           var chatRoom = await  _applicationContext.ChatRooms
           .Include(x => x.Messages)
           .AsSplitQuery()
           .SingleOrDefaultAsync(predicate);
           return chatRoom;
        }
    }
}