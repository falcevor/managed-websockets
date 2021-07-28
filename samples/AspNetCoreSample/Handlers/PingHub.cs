using ManagedWebSockets.Handlers;
using System.Threading.Tasks;

namespace AspNetCoreSample.Handlers
{
    public class PingHub : WebSocketHub
    {
        public override async Task ProcessMessage()
        {
            await Task.Delay(100);
        }
    }
}
