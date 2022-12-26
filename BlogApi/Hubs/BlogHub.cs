using Microsoft.AspNetCore.SignalR;

namespace BlogApi.Hubs
{
    public class BlogHub : Hub
    {
        public async Task SendMessage(string username, string message)
        {
            // Call the broadcastMessage method to update clients.
            await Clients.All.SendAsync("ReceiveMessage", username, message);
        }
    }
}
