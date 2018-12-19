using System.Threading;
using System.Threading.Tasks;
using Giftbit.API.Model.Request;
using Giftbit.API.Model.Response;

namespace Giftbit.API.Clients
{
    public interface IGiftsClient
    {
        Task<ListGiftsResponse> ListGifts(
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
            CancellationToken token = default);

        Task<GiftResponse> RetrieveGift(string uuid, CancellationToken token = default);

        Task<GiftResponse> ResendGift(string uuid, ResendGiftRequest request, CancellationToken token = default);

        Task<GiftResponse> CancelGift(string uuid, CancellationToken token = default);
    }
}