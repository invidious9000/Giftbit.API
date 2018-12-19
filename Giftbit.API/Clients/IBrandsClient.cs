using System.Threading;
using System.Threading.Tasks;
using Giftbit.API.Model.Response;

namespace Giftbit.API.Clients
{
    public interface IBrandsClient
    {
        Task<ListBrandsResponse> ListBrands(
            int? region = default,
            long? maxPriceInCents = default,
            long? minPriceInCents = default,
            string currencyIsoCode = default,
            string search = default,
            int? limit = default,
            int? offset = default,
            CancellationToken token = default);

        Task<RetrieveBrandResponse> RetrieveBrand(string brandCode, CancellationToken token = default);
    }
}