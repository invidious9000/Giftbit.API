using System.Threading;
using System.Threading.Tasks;
using Giftbit.API.Http;
using Giftbit.API.Model.Request;
using Giftbit.API.Model.Response;
using RestSharp;

namespace Giftbit.API.Clients.RestSharp
{
    public class CampaignClient : ICampaignClient
    {
        private readonly IConnection _connection;

        public CampaignClient(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<CreateCampaignResponse> CreateCampaign(CreateCampaignRequest request,
            CancellationToken token = default)
        {
            return await _connection
                .ExecuteRequest<CreateCampaignResponse>("/campaign", null, request, null, Method.POST, token);
        }

        public async Task<RetrieveCampaignResponse> RetrieveCampaignByIdOrUuid(string idOrUuid,
            CancellationToken token = default)
        {
            return await _connection
                .ExecuteRequest<RetrieveCampaignResponse>($"/campaign/{idOrUuid}", token: token);
        }
    }
}