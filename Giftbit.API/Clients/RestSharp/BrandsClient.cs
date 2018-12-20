using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Giftbit.API.Http;
using Giftbit.API.Model.Response;
using RestSharp;

namespace Giftbit.API.Clients.RestSharp
{
    public class BrandsClient : IBrandsClient
    {
        private readonly IConnection _connection;

        public BrandsClient(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<ListBrandsResponse> ListBrands(
            int? region = default,
            int? maxPriceInCents = default,
            int? minPriceInCents = default,
            string currencyIsoCode = default,
            string search = default,
            int? limit = default,
            int? offset = default,
            CancellationToken token = default)
        {
            var parameters = new List<Parameter>
            {
                new Parameter("region", region, ParameterType.QueryString),
                new Parameter("max_price_in_cents", maxPriceInCents, ParameterType.QueryString),
                new Parameter("min_price_in_cents", minPriceInCents, ParameterType.QueryString),
                new Parameter("currencyisocode", currencyIsoCode, ParameterType.QueryString),
                new Parameter("search", search, ParameterType.QueryString),
                new Parameter("limit", limit, ParameterType.QueryString),
                new Parameter("offset", offset, ParameterType.QueryString)
            };
            return await _connection
                .ExecuteRequest<ListBrandsResponse>("/brands", parameters, token: token);
        }

        public async Task<RetrieveBrandResponse> RetrieveBrand(string brandCode, CancellationToken token = default)
        {
            return await _connection
                .ExecuteRequest<RetrieveBrandResponse>($"/brands/{brandCode}", token: token);
        }
    }
}