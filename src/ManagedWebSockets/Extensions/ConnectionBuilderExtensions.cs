using Microsoft.AspNetCore.Connections;
using ManagedWebSockets.Handlers;

namespace ManagedWebSockets.Extensions
{
    internal static class ConnectionBuilderExtensions
    {
        public static IConnectionBuilder UseWebSocketHandler<THub>(this IConnectionBuilder builder)
            where THub : WebSocketHub
        {
            return builder.UseConnectionHandler<WebSocketConnectionHandler<THub>>();
        }
    }
}
