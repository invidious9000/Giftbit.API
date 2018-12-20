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
    public class BrandsClientTest
    {
        [Fact]
        public async Task CorrectRequestForListBrands()
        {
            var factory = Substitute.For<IConnection>();
            var client = new BrandsClient(factory);

            const int fakeRegion = 1;
            const int maxPriceInCents = 350;
            const int minPriceInCents = 300;
            const string currencyIso = "FAKE";
            const string search = "some_query";
            const int limit = 10;
            const int offset = 0;

            await client.ListBrands(
                region: fakeRegion,
                maxPriceInCents: maxPriceInCents,
                minPriceInCents: minPriceInCents,
                currencyIsoCode: currencyIso,
                search: search,
                limit: limit,
                offset: offset,
                token: CancellationToken.None);

            var parameters = Arg.Is<List<Parameter>>(list =>
                list.Any(parameter => parameter.Name == "region" && (int) parameter.Value == fakeRegion) &&
                list.Any(parameter =>
                    parameter.Name == "max_price_in_cents" && (int) parameter.Value == maxPriceInCents) &&
                list.Any(parameter =>
                    parameter.Name == "min_price_in_cents" && (int) parameter.Value == minPriceInCents) &&
                list.Any(parameter => parameter.Name == "currencyisocode" && (string) parameter.Value == currencyIso) &&
                list.Any(parameter => parameter.Name == "search" && (string) parameter.Value == search) &&
                list.Any(parameter => parameter.Name == "limit" && (int) parameter.Value == limit) &&
                list.Any(parameter => parameter.Name == "offset" && (int) parameter.Value == offset)
            );

            await factory.Received()
                .ExecuteRequest<ListBrandsResponse>("/brands", parameters, token: CancellationToken.None);
        }

        [Fact]
        public async Task CorrectRequestForRetrieveBrand()
        {
            var factory = Substitute.For<IConnection>();
            var client = new BrandsClient(factory);

            await client.RetrieveBrand("fake_brand", CancellationToken.None);

            await factory.Received()
                .ExecuteRequest<RetrieveBrandResponse>("/brands/fake_brand", token: CancellationToken.None);
        }
    }
}