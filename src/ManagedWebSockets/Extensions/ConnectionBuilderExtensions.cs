using Microsoft.AspNetCore.Connections;
using ManagedWebSockets.Handlers;

namespace ManagedWebSockets.Extensions
{
    internal static class ConnectionBuilderExtensions
    {
        public static IConnectionBuilder UseWebSocketHandler<THandler>(this IConnectionBuilder builder)
            where THandler : WebSocketHandler
        {
            builder.UseConnectionHandler<WebSocketConnectionHandler<THandler>>();
            return builder;
        }
    }
}
