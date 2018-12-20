using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Giftbit.API.Http;
using Giftbit.API.Model.Request;
using Giftbit.API.Model.Response;
using RestSharp;

namespace Giftbit.API.Clients.RestSharp
{
    public class GiftsClient : IGiftsClient
    {
        private readonly IConnection _connection;

        public GiftsClient(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<ListGiftsResponse> ListGifts(
            string uuid = default,
            string campaignUuid = default,
            string campaignId = default,
            int? priceInCentsGreaterThan = default,
            int? priceInCentsLessThan = default,
            string recipientName = default,
            string recipientEmail = default,
            string deliveryStatus = default,
            string status = default,
            string createdDateGreaterThan = default,
            string createdDateLessThan = default,
            string deliveryDateGreaterThan = default,
            string deliveryDateLessThan = default,
            int? redeliveryCountGreaterThan = default,
            int? redeliveryCountLessThan = default,
            string redeemedDateGreaterThan = default,
            string redeemedDateLessThan = default,
            int? limit = default,
            int? offset = default,
            string sort = default,
            string order = default,
            CancellationToken token = default)
        {
            var parameters = new List<Parameter>
            {
                new Parameter("uuid", uuid, ParameterType.QueryString),
                new Parameter("campaign_uuid", campaignUuid, ParameterType.QueryString),
                new Parameter("campaign_id", campaignId, ParameterType.QueryString),
                new Parameter("price_in_cents_greater_than", priceInCentsGreaterThan, ParameterType.QueryString),
                new Parameter("price_in_cents_less_than", priceInCentsLessThan, ParameterType.QueryString),
                new Parameter("recipient_name", recipientName, ParameterType.QueryString),
                new Parameter("recipient_email", recipientEmail, ParameterType.QueryString),
                new Parameter("delivery_status", deliveryStatus, ParameterType.QueryString),
                new Parameter("status", status, ParameterType.QueryString),
                new Parameter("created_date_greater_than", createdDateGreaterThan, ParameterType.QueryString),
                new Parameter("created_date_less_than", createdDateLessThan, ParameterType.QueryString),
                new Parameter("delivery_date_greater_than", deliveryDateGreaterThan, ParameterType.QueryString),
                new Parameter("delivery_date_less_than", deliveryDateLessThan, ParameterType.QueryString),
                new Parameter("redelivery_count_greater_than", redeliveryCountGreaterThan, ParameterType.QueryString),
                new Parameter("redelivery_count_less_than", redeliveryCountLessThan, ParameterType.QueryString),
                new Parameter("redeemed_date_greater_than", redeemedDateGreaterThan, ParameterType.QueryString),
                new Parameter("redeemed_date_less_than", redeemedDateLessThan, ParameterType.QueryString),
                new Parameter("limit", limit, ParameterType.QueryString),
                new Parameter("offset", offset, ParameterType.QueryString),
                new Parameter("sort", sort, ParameterType.QueryString),
                new Parameter("order", order, ParameterType.QueryString),
            };

            return await _connection
                .ExecuteRequest<ListGiftsResponse>("/gifts", parameters, token: token);
        }

        public async Task<GiftResponse> RetrieveGift(string uuid, CancellationToken token = default)
        {
            return await _connection
                .ExecuteRequest<GiftResponse>($"/gifts/{uuid}", token: token);
        }

        public async Task<GiftResponse> ResendGift(string uuid, ResendGiftRequest request,
            CancellationToken token = default)
        {
            return await _connection
                .ExecuteRequest<GiftResponse>($"/gifts/{uuid}", null, request, null, Method.PUT, token);
        }

        public async Task<GiftResponse> CancelGift(string uuid, CancellationToken token = default)
        {
            return await _connection
                .ExecuteRequest<GiftResponse>($"/gifts/{uuid}", method: Method.DELETE, token: token);
        }
    }
}