using GameRuls.Models;
using GameRuls.Models.Context;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameRuls.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message, string room, bool join)
        {
            if (join)
            {
                await JoinRoom(room).ConfigureAwait(false);
                await Clients.Group(room).SendAsync("ReceiveMessage", "Join the game to " + room).ConfigureAwait(true);
            }
            else
            {
                await Clients.Group(room).SendAsync("ReceiveMessage", message).ConfigureAwait(true);
            }
        }

        public Task JoinRoom(string roomName)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        }

        public Task LeaveRoom(string roomName)
        {
            Clients.Group(roomName).SendAsync("ReceiveMessage", "Player leave game" + roomName).ConfigureAwait(true);
            using (Context context = new Context())
            {
                var roomDelete = context.Rooms.Where(c => c.Name == roomName).ToList();
                context.Rooms.Remove(roomDelete[0]);
                context.SaveChanges();
            }
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }
    }
}