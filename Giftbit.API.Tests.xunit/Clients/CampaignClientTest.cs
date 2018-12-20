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
    public class CampaignClientTest
    {
        [Fact]
        public async Task CorrectRequestForCreateCampaign()
        {
            var factory = Substitute.For<IConnection>();
            var client = new CampaignClient(factory);

            var request = new CreateCampaignRequest();

            await client.CreateCampaign(request, CancellationToken.None);

            await factory.Received()
                .ExecuteRequest<CreateCampaignResponse>("/campaign", data: request, method: Method.POST,
                    token: CancellationToken.None);
        }

        [Fact]
        public async Task CorrectRequestForRetrieveCampaignByIdOrUuid()
        {
            var factory = Substitute.For<IConnection>();
            var client = new CampaignClient(factory);

            var fakeId = Guid.NewGuid().ToString();

            await client.RetrieveCampaignByIdOrUuid(fakeId, CancellationToken.None);

            await factory.Received()
                .ExecuteRequest<RetrieveCampaignResponse>($"/campaign/{fakeId}", token: CancellationToken.None);
        }
    }
}