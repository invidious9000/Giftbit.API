using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Giftbit.API.Http;
using Giftbit.API.Model.Response;
using RestSharp;

namespace Giftbit.API.Clients.RestSharp
{
    public class LinksClient : ILinksClient
    {
        private readonly IConnection _connection;

        public LinksClient(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<RetrieveShortlinksResponse> RetrieveShortlinksByIdOrUuid(string idOrUuid,
            int? limit = default,
            int? offset = default,
            CancellationToken token = default)
        {
            var parameters = new List<Parameter>
            {
                new Parameter("limit", limit, ParameterType.QueryString),
                new Parameter("offset", offset, ParameterType.QueryString)
            };
            return await _connection
                .ExecuteRequest<RetrieveShortlinksResponse>($"/links/{idOrUuid}", parameters, token: token);
        }
    }
}