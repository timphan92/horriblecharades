using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace webapi_signalr.Hubs
{
    public class Gamehub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}