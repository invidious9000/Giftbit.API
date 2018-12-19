using System.Threading;
using System.Threading.Tasks;
using Giftbit.API.Http;
using Giftbit.API.Model.Response;

namespace Giftbit.API.Clients.RestSharp
{
    public class RegionsClient : IRegionsClient
    {
        private readonly IConnection _connection;

        public RegionsClient(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<ListRegionsResponse> ListRegions(CancellationToken token = default)
        {
            return await _connection
                .ExecuteRequest<ListRegionsResponse>("/regions", token: token);
        }
    }
}