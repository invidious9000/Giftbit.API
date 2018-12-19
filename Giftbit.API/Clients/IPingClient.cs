using System.Threading;
using System.Threading.Tasks;
using Giftbit.API.Model.Response;

namespace Giftbit.API.Clients
{
    public interface IPingClient
    {
        Task<PingResponse> Ping(CancellationToken token = default);
    }
}