using Microsoft.AspNetCore.SignalR;

namespace SignalRChatApp.Hubs
{
    public class ChatHub:Hub
    {

        public async Task SendMessageAsync(string message)
        {
             await Clients.All.SendAsync("receiveMessage", message);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("userJoind", Context.ConnectionId);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.All.SendAsync("userLeaved", Context.ConnectionId);
        }
    }
}
