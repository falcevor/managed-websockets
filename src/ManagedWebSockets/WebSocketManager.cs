using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace ManagedWebSockets
{
    internal class WebSocketManager : IWebSocketManager
    {
        private ConcurrentDictionary<string, WebSocket> _sockets = new();

        public Task AddSocketAsync(WebSocket socket)
        {
            var socketId = GenerateSocketId();
            _sockets[socketId] = socket;
            return Task.CompletedTask;
        }

        public Task<WebSocket> GetSocketAsync(string socketId)
        {
            _sockets.TryGetValue(socketId, out var socket);
            return Task.FromResult(socket);
        }

        public Task<string> GetSocketIdAsync(WebSocket socket)
        {
            var socketId = _sockets.Where(x => x.Value == socket)
                .Select(x => x.Key)
                .FirstOrDefault();

            return Task.FromResult(socketId);
        }

        public Task RemoveSocketAsync(WebSocket socket)
        {
            var key = _sockets.Where(x => x.Value == socket)
                .Select(x => x.Key)
                .FirstOrDefault();

            if (key is not null)
                _sockets.TryRemove(key, out _);

            return Task.CompletedTask;
        }

        private string GenerateSocketId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
