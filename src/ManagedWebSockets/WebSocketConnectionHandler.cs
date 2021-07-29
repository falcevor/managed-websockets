using ManagedWebSockets.Handlers;
using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.Logging;
using System.Net.WebSockets;
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
            Handle(connection.Items["message"].ToString());
        }



        private void Handle(string message)
        {
            _logger.LogInformation(message);
        }
    }
}
