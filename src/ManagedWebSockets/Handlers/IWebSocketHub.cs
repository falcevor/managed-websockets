using System.Threading.Tasks;

namespace ManagedWebSockets.Handlers
{
    internal interface IWebSocketHub<TIn, TOut>
    {
        Task ConnectAsync();
        Task DisconnectAsync();
        Task RecieveMessageAsync();
    }
}
