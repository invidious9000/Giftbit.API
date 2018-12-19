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
            long? priceInCentsGreaterThan = default,
            long? priceInCentsLessThan = default,
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
            return await _connection
                .ExecuteRequest<ListGiftsResponse>("/gifts" +
                                                   $"?uuid={uuid}" +
                                                   $"&campaign_uuid={campaignUuid}" +
                                                   $"&campaign_id={campaignId}" +
                                                   $"&price_in_cents_greater_than={priceInCentsGreaterThan}" +
                                                   $"&price_in_cents_less_than={priceInCentsLessThan}" +
                                                   $"&recipient_name={recipientName}" +
                                                   $"&recipient_email={recipientEmail}" +
                                                   $"&delivery_status={deliveryStatus}" +
                                                   $"&status={status}" +
                                                   $"&created_date_greater_than={createdDateGreaterThan}" +
                                                   $"&created_date_less_than={createdDateLessThan}" +
                                                   $"&delivery_date_greater_than={deliveryDateGreaterThan}" +
                                                   $"&delivery_date_less_than={deliveryDateLessThan}" +
                                                   $"&redelivery_count_greater_than={redeliveryCountGreaterThan}" +
                                                   $"&redelivery_count_less_than={redeliveryCountLessThan}" +
                                                   $"&redeemed_date_greater_than={redeemedDateGreaterThan}" +
                                                   $"&redeemed_date_less_than={redeemedDateLessThan}" +
                                                   $"&limit={limit}" +
                                                   $"&offset={offset}" +
                                                   $"&sort={sort}" +
                                                   $"&order={order}", null, null, "/gifts", token: token);
        }

        public async Task<GiftResponse> RetrieveGift(string uuid, CancellationToken token = default)
        {
            return await _connection
                .ExecuteRequest<GiftResponse>($"/gifts/{uuid}", null, null, "/gifts", token: token);
        }

        public async Task<GiftResponse> ResendGift(string uuid, ResendGiftRequest request,
            CancellationToken token = default)
        {
            return await _connection
                .ExecuteRequest<GiftResponse>($"/gifts/{uuid}", null, request, "/gifts", Method.PUT, token);
        }

        public async Task<GiftResponse> CancelGift(string uuid, CancellationToken token = default)
        {
            return await _connection
                .ExecuteRequest<GiftResponse>($"/gifts/{uuid}", null, null, "/gifts", Method.DELETE, token);
        }
    }
}