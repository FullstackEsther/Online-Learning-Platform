using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Chat
{
    public class Message
    {
        public Guid Id { get; set;}
        public Guid ChatRoomId { get; set; }
        public required string SenderUserName { get; set; }
        public required string Content { get; set; }
        public DateTime Timestamp { get; set; }
    }
}