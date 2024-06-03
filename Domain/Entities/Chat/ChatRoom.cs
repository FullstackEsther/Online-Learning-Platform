using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Chat
{
    public class ChatRoom : BaseClass
    {
        public  string? RoomName{get; set;} 
        public  bool IsGroupChat{get; set;} = default!;
        public  string SenderUserName{get; set;} = default!;
        public  string? ReceiverUserName{get; set;} 
        public  ICollection<Message> Messages{get; set;}
        public ChatRoom()
        {
            Messages = new HashSet<Message>();
        } 

        public void AddMessage(Message message)
        {
            if (message == null)
            {
                throw new ArgumentException("Cannot add an empty message");   
            }
            else
            {
                Messages.Add(message);
            }
        }
    }
}