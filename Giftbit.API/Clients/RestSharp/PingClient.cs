using System.Threading;
using System.Threading.Tasks;
using Giftbit.API.Http;
using Giftbit.API.Model.Response;

namespace Giftbit.API.Clients.RestSharp
{
    public class PingClient : IPingClient
    {
        private readonly IConnection _connection;

        public PingClient(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<PingResponse> Ping(CancellationToken token = default)
        {
            return await _connection.ExecuteRequest<PingResponse>("/ping", token: token);
        }
    }
}