using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            var brandsClient = new BrandsClient(factory);

            const int fakeRegion = 1;
            const long maxPriceInCents = 350L;
            const long minPriceInCents = 300L;
            const string currencyIso = "FAKE";
            const string search = "some_query";
            const int limit = 10;
            const int offset = 0;

            await brandsClient.ListBrands(
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
                    parameter.Name == "max_price_in_cents" && (long) parameter.Value == maxPriceInCents) &&
                list.Any(parameter =>
                    parameter.Name == "min_price_in_cents" && (long) parameter.Value == minPriceInCents) &&
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
            var brandsClient = new BrandsClient(factory);

            await brandsClient.RetrieveBrand("fake_brand", CancellationToken.None);

            await factory.Received()
                .ExecuteRequest<RetrieveBrandResponse>("/brands/fake_brand", token: CancellationToken.None);
        }
    }
}