using System.Threading;
using System.Threading.Tasks;
using Giftbit.API.Model.Response;

namespace Giftbit.API.Clients
{
    public interface IRegionsClient
    {
        Task<ListRegionsResponse> ListRegions(CancellationToken token = default);
    }
}