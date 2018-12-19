using System.Threading;
using System.Threading.Tasks;
using Giftbit.API.Model.Request;
using Giftbit.API.Model.Response;

namespace Giftbit.API.Clients
{
    public interface ICampaignClient
    {
        Task<CreateCampaignResponse> CreateCampaign(CreateCampaignRequest request, CancellationToken token = default);
        Task<RetrieveCampaignResponse> RetrieveCampaignByIdOrUuid(string idOrUuid, CancellationToken token = default);
    }
}