﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Giftbit.API.Exceptions;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Extensions;

namespace Giftbit.API.Extensions
{
    public static class RestSharpExtensions
    {
        public static async Task<T> ExecuteTask<T>(this IRestClient client, IRestRequest request,
            CancellationToken token = default)
            where T : new()
        {
            var ret = await client.ExecuteTaskAsync(request, token).ConfigureAwait(false);
            return ret.ThrowIfException().Deserialize<T>();
        }

        public static async Task<IRestResponse> ExecuteTaskRaw(this IRestClient client, IRestRequest request,
            CancellationToken token = default)
        {
            var ret = await client.ExecuteTaskAsync(request, token).ConfigureAwait(false);
            request.OnBeforeDeserialization(ret);
            return ret.ThrowIfException();
        }

        private static IRestResponse ThrowIfException(this IRestResponse response)
        {
            if (response.ErrorException != null)
                throw new ApplicationException("There was an an exception thrown during the request.",
                    response.ErrorException);

            if (response.ResponseStatus != ResponseStatus.Completed) throw response.ResponseStatus.ToWebException();

            if ((int) response.StatusCode >= 400) throw new ApiException(response.StatusCode, response.Content);

            return response;
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public static T Deserialize<T>(this IRestResponse response)
        {
            response.Request.OnBeforeDeserialization(response);
            var deserialize = new JsonDeserializer
            {
                RootElement = response.Request.RootElement,
                DateFormat = response.Request.DateFormat
            };
            return deserialize.Deserialize<T>(response);
        }
    }
}