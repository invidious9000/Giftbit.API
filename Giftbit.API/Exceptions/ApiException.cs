using System;
using System.Collections.Generic;
using System.Net;

namespace Giftbit.API.Exceptions
{
    public class ApiException : Exception
    {
        private readonly IDictionary<int, string> _errors = new Dictionary<int, string>
        {
            {401, "Access Denied"},
            {404, "Not Found"}
        };

        private readonly string _errorResponseContent;

        // ReSharper disable once MemberCanBePrivate.Global
        public HttpStatusCode StatusCode { get; }

        public override string Message => _errors.ContainsKey((int) StatusCode)
            ? _errors[(int) StatusCode]
            : $"Unknown API error, StatusCode: {StatusCode}, Content: {_errorResponseContent}";

        public ApiException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public ApiException(HttpStatusCode statusCode, string errorResponseContent)
        {
            StatusCode = statusCode;
            _errorResponseContent = errorResponseContent;
        }
    }
}