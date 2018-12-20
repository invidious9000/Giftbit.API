using System.Threading;
using System.Threading.Tasks;
using Giftbit.API.Clients.RestSharp;
using Giftbit.API.Http;
using Giftbit.API.Model.Response;
using NSubstitute;
using Xunit;

namespace Giftbit.API.Tests.xunit.Clients
{
    public class RegionsClientTest
    {
        [Fact]
        public async Task CorrectRequestForListRegions()
        {
            var factory = Substitute.For<IConnection>();
            var client = new RegionsClient(factory);

            await client.ListRegions(CancellationToken.None);

            await factory.Received().ExecuteRequest<ListRegionsResponse>("/regions", token: CancellationToken.None);
        }
    }
}