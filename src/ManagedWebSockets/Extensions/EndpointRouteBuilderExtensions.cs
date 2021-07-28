using ManagedWebSockets.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace ManagedWebSockets.Extensions
{
    public class EndpointRouteBuilderExtensions
    {
        public static IEndpointRouteBuilder MapWebSocketHandler<THandler>(IEndpointRouteBuilder builder, string pattern) 
            where THandler : WebSocketHandler
        {
            builder.MapConnections(pattern, config => config.UseWebSocketHandler<THandler>());
            return builder;
        }
    }
}
