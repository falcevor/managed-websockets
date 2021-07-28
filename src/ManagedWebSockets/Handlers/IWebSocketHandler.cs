using System.Threading.Tasks;

namespace ManagedWebSockets.Handlers
{
    public interface IWebSocketHandler<TIn, TOut>
    {
        Task ConnectAsync();
        Task DisconnectAsync();
        Task ProcessMessage();
    }
}
