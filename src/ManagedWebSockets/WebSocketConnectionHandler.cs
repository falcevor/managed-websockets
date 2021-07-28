using ManagedWebSockets.Handlers;
using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ManagedWebSockets
{
    internal class WebSocketConnectionHandler<THandler> : ConnectionHandler 
        where THandler : WebSocketHandler
    {

        private ILogger<WebSocketConnectionHandler<THandler>> _logger;

        public WebSocketConnectionHandler(ILogger<WebSocketConnectionHandler<THandler>> logger)
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
