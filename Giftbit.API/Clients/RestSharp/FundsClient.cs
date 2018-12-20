using System.Threading;
using System.Threading.Tasks;
using Giftbit.API.Http;
using Giftbit.API.Model.Request;
using Giftbit.API.Model.Response;
using RestSharp;

namespace Giftbit.API.Clients.RestSharp
{
    public class FundsClient : IFundsClient
    {
        private readonly IConnection _connection;

        public FundsClient(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<FundingInformationResponse> RetrieveFundingInformation(CancellationToken token = default)
        {
            return await _connection
                .ExecuteRequest<FundingInformationResponse>("/funds", token: token);
        }

        public async Task<FundingInformationResponse> AddFundsThroughCreditCard(AddFundsRequest request,
            CancellationToken token = default)
        {
            return await _connection
                .ExecuteRequest<FundingInformationResponse>("/funds", null, request, null, Method.POST, token);
        }
    }
}