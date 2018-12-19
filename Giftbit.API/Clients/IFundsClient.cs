using System.Threading;
using System.Threading.Tasks;
using Giftbit.API.Model.Request;
using Giftbit.API.Model.Response;

namespace Giftbit.API.Clients
{
    public interface IFundsClient
    {
        Task<FundingInformationResponse> RetrieveFundingInformation(CancellationToken token = default);

        Task<FundingInformationResponse> AddFundsThroughCreditCard(AddFundsRequest request,
            CancellationToken token = default);
    }
}