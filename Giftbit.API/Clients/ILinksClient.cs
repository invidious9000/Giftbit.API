using System.Threading;
using System.Threading.Tasks;
using Giftbit.API.Model.Response;

namespace Giftbit.API.Clients
{
    public interface ILinksClient
    {
        Task<RetrieveShortlinksResponse> RetrieveShortlinksByIdOrUuid(string idOrUuid, int? limit = default,
            int? offset = default, CancellationToken token = default);
    }
}