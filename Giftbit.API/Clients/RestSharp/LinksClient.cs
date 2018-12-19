using System.Threading;
using System.Threading.Tasks;
using Giftbit.API.Http;
using Giftbit.API.Model.Response;

namespace Giftbit.API.Clients.RestSharp
{
    public class LinksClient : ILinksClient
    {
        private readonly IConnection _connection;

        public LinksClient(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<RetrieveShortlinksResponse> RetrieveShortlinksByIdOrUuid(string idOrUuid, int? limit = default,
            int? offset = default, CancellationToken token = default)
        {
            return await _connection
                .ExecuteRequest<RetrieveShortlinksResponse>($"/links/{idOrUuid}" +
                                                            $"?limit={limit}" +
                                                            $"&offset={offset}", null, null, "/links", token: token);
        }
    }
}