using System.Net.WebSockets;
using System.Threading.Tasks;

namespace ManagedWebSockets
{
    internal interface IWebSocketManager
    {
        Task AddSocketAsync(WebSocket socket);
        Task<string> GetSocketIdAsync(WebSocket socket);
        Task<WebSocket> GetSocketAsync(string socketId);
        Task RemoveSocketAsync(WebSocket socket);
    }
}
