using System.Threading.Tasks;

namespace ManagedWebSockets.Handlers
{
    public abstract class WebSocketHandler : IWebSocketHandler<string, string>
    {
        public Task ConnectAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task DisconnectAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task ProcessMessage()
        {
            throw new System.NotImplementedException();
        }
    }
}
