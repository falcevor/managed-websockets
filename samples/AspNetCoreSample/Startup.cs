using AspNetCoreSample.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ManagedWebSockets.Extensions;

namespace AspNetCoreSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddManagedWebSockets();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapWebSocketHandler<PingHub>("/ws");
            });
        }
    }
}
