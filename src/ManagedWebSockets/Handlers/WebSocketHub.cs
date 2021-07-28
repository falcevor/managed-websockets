using System.Threading.Tasks;

namespace ManagedWebSockets.Handlers
{
    public abstract class WebSocketHub : IWebSocketHub<string, string>
    {
        async Task IWebSocketHub<string, string>.ConnectAsync()
        {
            await OnConnectingAsync();
        }

        async Task IWebSocketHub<string, string>.DisconnectAsync()
        {
            await OnDisconnectingAsync();
        }

        async Task IWebSocketHub<string, string>.RecieveMessageAsync()
        {
            await ProcessMessage();
        }

        public virtual Task OnConnectingAsync() => Task.CompletedTask;
        public virtual Task OnDisconnectingAsync() => Task.CompletedTask;
        public abstract Task ProcessMessage();
    }
}
