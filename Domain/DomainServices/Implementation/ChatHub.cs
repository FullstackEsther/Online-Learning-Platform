using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.RepositoryInterfaces;
using Microsoft.AspNetCore.SignalR;

namespace Domain.Entities.Chat
{
    public class ChatHub : Hub
    {
        private readonly IChatRepository _chatRepository;
        public ChatHub(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }
        public async Task SendMessageToGroup(string RoomName, string senderUserName, string content)
        {
            var chatRoom = await _chatRepository.Get(x => x.RoomName == RoomName);
            Message message = new Message
            {
                ChatRoomId = chatRoom.Id,
                Content = content,
                SenderUserName = senderUserName,
                Timestamp = DateTime.UtcNow,
            };
            chatRoom.AddMessage(message);
            _chatRepository.Update(chatRoom);
            await Clients.Group(RoomName).SendAsync("ReceiveMessage", message);
        }

        public async Task SendMessageToIndividual(string chatRoomId, string senderUserName, string content, string receiverUserName)
        {
            var chatRoom = await _chatRepository.Get(x => x.Id == Guid.Parse(chatRoomId));// I will adjust this when I create my service 
            Message message = new Message
            {
                ChatRoomId = chatRoom.Id,
                Content = content,
                SenderUserName = senderUserName,
                Timestamp = DateTime.UtcNow,
            };
            chatRoom.AddMessage(message);
            _chatRepository.Update(chatRoom);
            await Clients.User(senderUserName).SendAsync("ReceiveMessage", senderUserName, content);
            await Clients.User(receiverUserName).SendAsync("ReceiveMessage", senderUserName, content);
        }
        public async Task JoinRoom(string roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
        }

        public async Task LeaveRoom(string roomId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId);
        }
    }
}