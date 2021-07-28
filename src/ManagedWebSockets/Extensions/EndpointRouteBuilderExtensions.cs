using ManagedWebSockets.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Routing;

namespace ManagedWebSockets.Extensions
{
    public static class EndpointRouteBuilderExtensions
    {
        public static IEndpointRouteBuilder MapWebSocketHandler<THub>(this IEndpointRouteBuilder endpoints, string pattern) 
            where THub : WebSocketHub
        {
            var connectionBuilder = new ConnectionBuilder(endpoints.ServiceProvider);
            connectionBuilder.UseWebSocketHandler<THub>();
            var connectionDelegate = connectionBuilder.Build();

            var app = endpoints.CreateApplicationBuilder();
            app.UseWebSockets();
            app.Run(c => )

            
            return endpoints;
        }
    }
}
