using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Giftbit.API.Extensions;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace Giftbit.API.Http
{
    public class Connection : IConnection
    {
        public Connection(IRestClient client)
        {
            Client = client;
        }

        public IRestClient Client { get; }

        public async Task<IRestResponse> ExecuteRaw(string endpoint, IEnumerable<Parameter> parameters,
            object data = null, Method method = Method.GET, CancellationToken token = default)
        {
            var request = BuildRequest(endpoint, parameters);
            request.Method = method;

            if (data == null || method == Method.GET)
                return await Client.ExecuteTaskRaw(request, token).ConfigureAwait(false);

            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new JsonNetSerializer();
            request.AddBody(data);

            return await Client.ExecuteTaskRaw(request, token).ConfigureAwait(false);
        }

        public async Task<T> ExecuteRequest<T>(string endpoint, IEnumerable<Parameter> parameters, object data = null,
            string expectedRoot = null, Method method = Method.GET, CancellationToken token = default) where T : new()
        {
            var request = BuildRequest(endpoint, parameters);
            request.RootElement = expectedRoot;
            request.Method = method;

            if (data == null || method == Method.GET)
                return await Client.ExecuteTask<T>(request, token).ConfigureAwait(false);

            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new JsonNetSerializer();
            request.AddBody(data);

            return await Client.ExecuteTask<T>(request, token).ConfigureAwait(false);
        }


        private static IRestRequest BuildRequest(string endpoint, IEnumerable<Parameter> parameters)
        {
            var request = new RestRequest(endpoint);

            if (parameters == null) return request;
            foreach (var parameter in parameters) request.AddParameter(parameter);

            return request;
        }
    }

    internal class JsonNetSerializer : ISerializer
    {
        private readonly JsonSerializer _serializer;

        public JsonNetSerializer()
        {
            ContentType = "application/json";
            _serializer = new JsonSerializer
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Include
            };
        }

        #region ISerializer Members

        public string Serialize(object obj)
        {
            using (var stringWriter = new StringWriter())
            using (var jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonTextWriter.QuoteChar = '"';
                _serializer.Serialize(jsonTextWriter, obj);
                var result = stringWriter.ToString();
                return result;
            }
        }

        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }
        public string ContentType { get; set; }

        #endregion
    }
}