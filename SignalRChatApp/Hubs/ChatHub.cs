using Microsoft.AspNetCore.SignalR;

namespace SignalRChatApp.Hubs
{
    public class ChatHub:Hub
    {

        public async Task SendMessageAsync(string message)
        {
             await Clients.All.SendAsync("receiveMessage", message);
        }
    }
}
