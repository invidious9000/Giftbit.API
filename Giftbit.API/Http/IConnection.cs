using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;

namespace Giftbit.API.Http
{
    public interface IConnection
    {
        IRestClient Client { get; }

        Task<IRestResponse> ExecuteRaw(string endpoint, IEnumerable<Parameter> parameters, object data = null,
            Method method = Method.GET, CancellationToken token = default);

        Task<T> ExecuteRequest<T>(string endpoint, IEnumerable<Parameter> parameters= null,
            object data = null, string expectedRoot = null, Method method = Method.GET,
            CancellationToken token = default) where T : new();
    }
}