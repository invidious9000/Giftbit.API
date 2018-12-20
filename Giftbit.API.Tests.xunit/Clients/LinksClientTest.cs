using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Giftbit.API.Clients.RestSharp;
using Giftbit.API.Http;
using Giftbit.API.Model.Response;
using NSubstitute;
using RestSharp;
using Xunit;

namespace Giftbit.API.Tests.xunit.Clients
{
    public class LinksClientTest
    {
        [Fact]
        public async Task CorrectRequestForRetrieveShortlinksByIdOrUuid()
        {
            var factory = Substitute.For<IConnection>();
            var client = new LinksClient(factory);

            var idOrUuid = Guid.NewGuid().ToString();
            const int limit = 10;
            const int offset = 0;

            await client.RetrieveShortlinksByIdOrUuid(idOrUuid, limit, offset, CancellationToken.None);

            var parameters = Arg.Is<List<Parameter>>(list =>
                list.Any(parameter => parameter.Name == "limit" && (int) parameter.Value == limit) &&
                list.Any(parameter => parameter.Name == "offset" && (int) parameter.Value == offset)
            );

            await factory.Received()
                .ExecuteRequest<RetrieveShortlinksResponse>($"/links/{idOrUuid}", parameters,
                    token: CancellationToken.None);
        }
    }
}