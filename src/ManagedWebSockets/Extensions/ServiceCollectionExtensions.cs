using Microsoft.AspNetCore.WebSockets;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ManagedWebSockets.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddManagedWebSockets(this IServiceCollection services)
        {
            return services.AddWebSockets(opt => opt.KeepAliveInterval = TimeSpan.FromSeconds(30));
        }
    }
}
