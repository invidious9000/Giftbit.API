using System.Threading;
using System.Threading.Tasks;
using Giftbit.API.Model.Response;

namespace Giftbit.API.Clients
{
    public interface IBrandsClient
    {
        Task<ListBrandsResponse> ListBrands(
            int? region = default,
            int? maxPriceInCents = default,
            int? minPriceInCents = default,
            string currencyIsoCode = default,
            string search = default,
            int? limit = default,
            int? offset = default,
            CancellationToken token = default);

        Task<RetrieveBrandResponse> RetrieveBrand(string brandCode, CancellationToken token = default);
    }
}