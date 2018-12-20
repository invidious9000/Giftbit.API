using System;
using System.Threading;
using System.Threading.Tasks;
using Giftbit.API.Clients.RestSharp;
using Giftbit.API.Http;
using Giftbit.API.Model.Request;
using Giftbit.API.Model.Response;
using NSubstitute;
using RestSharp;
using Xunit;

namespace Giftbit.API.Tests.xunit.Clients
{
    public class FundsClientTest
    {
        [Fact]
        public async Task CorrectRequestForRetrieveFundingInformation()
        {
            var factory = Substitute.For<IConnection>();
            var client = new FundsClient(factory);

            await client.RetrieveFundingInformation(CancellationToken.None);

            await factory.Received().ExecuteRequest<FundingInformationResponse>("/funds", token: CancellationToken.None);
        }

        [Fact]
        public async Task CorrectRequestForAddFunds()
        {
            var factory = Substitute.For<IConnection>();
            var client = new FundsClient(factory);

            var request = new AddFundsRequest
            {
                Id = Guid.NewGuid().ToString(),
                FundAmountInCents = 350,
                CurrencyIsoCode = "USD"
            };

            await client.AddFundsThroughCreditCard(request, CancellationToken.None);

            await factory.Received().ExecuteRequest<FundingInformationResponse>("/funds", null, request, null,
                Method.POST, CancellationToken.None);
        }
    }
}