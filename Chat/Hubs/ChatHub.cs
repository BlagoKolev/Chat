using Chat.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        static HashSet<string> connectedUsers = new HashSet<string>();
        static Dictionary<string, string> messageContainer = new();
      
        public async Task SendGlobalMessage()
        {
            var username = GetUsername();
            await Clients.All.SendAsync("receiveGlobalMessage", username);
        }

        public override Task OnConnectedAsync()
        {
            //var connectionId = Context.ConnectionId;

            var userName = GetUsername();

            connectedUsers.Add(userName);

            Clients.All
                .SendAsync("updateConnectedUsers", connectedUsers)
                .GetAwaiter()
                .GetResult();

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var username = GetUsername();
            connectedUsers.Remove(username);
            Clients.All
                .SendAsync("updateConnectedUsers", connectedUsers)
                .GetAwaiter()
                .GetResult();
            return base.OnDisconnectedAsync(exception);
        }

        private string GetUsername()
        {
            var user = Context.User.Identity;
            var index = user.Name.IndexOf('@');
            var username = user.Name.Substring(0, index);
            return username;
        }

    }
}
