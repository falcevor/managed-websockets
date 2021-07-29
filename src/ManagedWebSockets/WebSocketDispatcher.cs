using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManagedWebSockets
{
    public class WebSocketDispatcher
    {
        private ILogger<WebSocketDispatcher> _logger;

        public WebSocketDispatcher(ILogger<WebSocketDispatcher> logger)
        {
            _logger = logger;
        }

        public async Task DispatchAsync(HttpContext context, ConnectionDelegate connectionDelegate)
        {
            
            if (context.WebSockets.IsWebSocketRequest)
            {
                using var socket = await context.WebSockets.AcceptWebSocketAsync();

                

                await Task.Run(async () => {
                    while (true)
                    {
                        var message = await ReceiveStringAsync(socket, CancellationToken.None);
                        var ctx = new DefaultConnectionContext();
                        ctx.Items["message"] = message;
                        await connectionDelegate.Invoke(ctx);
                    }
                });
            }
        }

        private Task SendStringAsync(WebSocket socket, string data, CancellationToken ct = default)
        {
            var buffer = Encoding.UTF8.GetBytes(data);
            var segment = new ArraySegment<byte>(buffer);
            return socket.SendAsync(segment, WebSocketMessageType.Text, true, ct);
        }

        private async Task<string> ReceiveStringAsync(
            WebSocket socket, 
            CancellationToken ct = default)
        {
            using var ms = await FetchToSteamByChunks(socket, ct);
            using var reader = new StreamReader(ms, Encoding.UTF8);
            return await reader.ReadToEndAsync();
        }

        private async Task<MemoryStream> FetchToSteamByChunks(
            WebSocket socket,
            CancellationToken ct)
        {
            var buffer = new ArraySegment<byte>(new byte[8192]);
            var ms = new MemoryStream();

            WebSocketReceiveResult result;
            do
            {
                ct.ThrowIfCancellationRequested();

                result = await socket.ReceiveAsync(buffer, ct);
                ms.Write(buffer.Array, buffer.Offset, result.Count);
            }
            while (!result.EndOfMessage);

            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }
    }
}
