using Microsoft.AspNetCore.SignalR;

namespace ChatApi.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string username, string message)
        {
            // Call the broadcastMessage method to update clients.
            await Clients.All.SendAsync("ReceiveMessage", username, message);
        }
    }
}
