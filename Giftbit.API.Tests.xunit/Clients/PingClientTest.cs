using System.Threading;
using System.Threading.Tasks;
using Giftbit.API.Clients.RestSharp;
using Giftbit.API.Http;
using Giftbit.API.Model.Response;
using NSubstitute;
using Xunit;

namespace Giftbit.API.Tests.xunit.Clients
{
    public class PingClientTest
    {
        [Fact]
        public async Task CorrectRequestForPing()
        {
            var factory = Substitute.For<IConnection>();
            var client = new PingClient(factory);

            await client.Ping(CancellationToken.None);

            await factory.Received().ExecuteRequest<PingResponse>("/ping", token: CancellationToken.None);
        }
    }
}