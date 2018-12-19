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
            var pingClient = new PingClient(factory);
            await pingClient.Ping(CancellationToken.None);
            await factory.Received().ExecuteRequest<PingResponse>("/ping", token: CancellationToken.None);
        }
    }
}