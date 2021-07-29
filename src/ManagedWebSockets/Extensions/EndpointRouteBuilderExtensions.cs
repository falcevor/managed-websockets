using ManagedWebSockets.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
            var logger = endpoints.ServiceProvider.GetRequiredService<ILogger<WebSocketDispatcher>>();
            var dispatcher = new WebSocketDispatcher(logger);
            app.Run(async c => await dispatcher.DispatchAsync(c, connectionDelegate));
            var executehandler = app.Build();

            var executeBuilder = endpoints.Map(pattern, executehandler);

            return endpoints;
        }

    }
}
