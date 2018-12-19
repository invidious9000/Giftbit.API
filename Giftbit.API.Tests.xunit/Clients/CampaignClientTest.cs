using System.Threading;
using System.Threading.Tasks;
using Giftbit.API.Clients.RestSharp;
using Giftbit.API.Http;
using Giftbit.API.Model.Response;
using NSubstitute;
using Xunit;

namespace Giftbit.API.Tests.xunit.Clients
{
    public class CampaignClientTest
    {
        [Fact]
        public async Task CorrectRequestForCreateCampaign()
        {
            var factory = Substitute.For<IConnection>();
            var brandsClient = new CampaignClient(factory);

            await brandsClient.CreateCampaign(null, CancellationToken.None);

            await factory.Received()
                .ExecuteRequest<CreateCampaignResponse>("/brands/fake_brand", token: CancellationToken.None);

            /*
             *         return await _connection
                .ExecuteRequest<CreateCampaignResponse>("/campaign", null, request, "/campaign", Method.POST, token);
     
             */
        }

        [Fact]
        public async Task CorrectRequestForRetrieveCampaignByIdOrUuid()
        {
            var factory = Substitute.For<IConnection>();
            var brandsClient = new CampaignClient(factory);

            await brandsClient.CreateCampaign(null, CancellationToken.None);

            await factory.Received()
                .ExecuteRequest<CreateCampaignResponse>("/brands/fake_brand", token: CancellationToken.None);

            /*
               return await _connection
                .ExecuteRequest<RetrieveCampaignResponse>($"/campaign/{idOrUuid}", null, null, "/campaign",
                    token: token);
      
     
             */
        }
    }
}