using ManagedWebSockets.Handlers;
using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ManagedWebSockets
{
    internal class WebSocketConnectionHandler<THub> : ConnectionHandler 
        where THub : WebSocketHub
    {

        private ILogger<WebSocketConnectionHandler<THub>> _logger;

        public WebSocketConnectionHandler(ILogger<WebSocketConnectionHandler<THub>> logger)
        {
            _logger = logger;
        }

        public override async Task OnConnectedAsync(ConnectionContext connection)
        {
            await DispatchMessage();
        }

        private async Task DispatchMessage()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    _logger.LogInformation("test");
                }
            });
        }
    }
}
