using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Giftbit.API.Clients.RestSharp;
using Giftbit.API.Http;
using Giftbit.API.Model.Request;
using Giftbit.API.Model.Response;
using NSubstitute;
using RestSharp;
using Xunit;

namespace Giftbit.API.Tests.xunit.Clients
{
    public class GiftsClientTest
    {
        [Fact]
        public async Task CorrectRequestForListBrands()
        {
            var factory = Substitute.For<IConnection>();
            var client = new GiftsClient(factory);

            var uuid = Guid.NewGuid().ToString();
            var campaignUuid = Guid.NewGuid().ToString();
            var campaignId = Guid.NewGuid().ToString();
            const int priceInCentsGreaterThan = 10;
            const int priceInCentsLessThan = 20;
            const string recipientName = "RECIPIENT";
            const string recipientEmail = "recip@ient.com";
            const string deliveryStatus = "DUNNO";
            const string status = "CLAIMED?";
            const string createdDateGreaterThan = "01-01-2018";
            const string createdDateLessThan = "01-01-2019";
            const string deliveryDateGreaterThan = "01-01-2018";
            const string deliveryDateLessThan = "01-01-2019";
            const int redeliveryCountGreaterThan = 1;
            const int redeliveryCountLessThan = 2;
            const string redeemedDateGreaterThan = "01-01-2019";
            const string redeemedDateLessThan = "01-01-2019";
            const int limit = 10;
            const int offset = 0;
            const string sort = "ASC";
            const string order = "status";

            await client.ListGifts(
                uuid: uuid,
                campaignUuid: campaignUuid,
                campaignId: campaignId,
                priceInCentsGreaterThan: priceInCentsGreaterThan,
                priceInCentsLessThan: priceInCentsLessThan,
                recipientName: recipientName,
                recipientEmail: recipientEmail,
                deliveryStatus: deliveryStatus,
                status: status,
                createdDateGreaterThan: createdDateGreaterThan,
                createdDateLessThan: createdDateLessThan,
                deliveryDateGreaterThan: deliveryDateGreaterThan,
                deliveryDateLessThan: deliveryDateLessThan,
                redeliveryCountGreaterThan: redeliveryCountGreaterThan,
                redeliveryCountLessThan: redeliveryCountLessThan,
                redeemedDateGreaterThan: redeemedDateGreaterThan,
                redeemedDateLessThan: redeemedDateLessThan,
                limit: limit,
                offset: offset,
                sort: sort,
                order: order,
                token: CancellationToken.None);

            var parameters = Arg.Is<List<Parameter>>(list =>
                list.Any(parameter => parameter.Name == "uuid" && (string) parameter.Value == uuid) &&
                list.Any(parameter => parameter.Name == "campaign_uuid" && (string) parameter.Value == campaignUuid) &&
                list.Any(parameter => parameter.Name == "campaign_id" && (string) parameter.Value == campaignId) &&
                list.Any(parameter => parameter.Name == "price_in_cents_greater_than" &&
                                      (int) parameter.Value == priceInCentsGreaterThan) &&
                list.Any(parameter => parameter.Name == "price_in_cents_less_than" &&
                                      (int) parameter.Value == priceInCentsLessThan) &&
                list.Any(parameter =>
                    parameter.Name == "recipient_name" && (string) parameter.Value == recipientName) &&
                list.Any(parameter =>
                    parameter.Name == "recipient_email" && (string) parameter.Value == recipientEmail) &&
                list.Any(parameter =>
                    parameter.Name == "delivery_status" && (string) parameter.Value == deliveryStatus) &&
                list.Any(parameter => parameter.Name == "status" && (string) parameter.Value == status) &&
                list.Any(parameter => parameter.Name == "created_date_greater_than" &&
                                      (string) parameter.Value == createdDateGreaterThan) &&
                list.Any(parameter => parameter.Name == "created_date_less_than" &&
                                      (string) parameter.Value == createdDateLessThan) &&
                list.Any(parameter => parameter.Name == "delivery_date_greater_than" &&
                                      (string) parameter.Value == deliveryDateGreaterThan) &&
                list.Any(parameter => parameter.Name == "delivery_date_less_than" &&
                                      (string) parameter.Value == deliveryDateLessThan) &&
                list.Any(parameter => parameter.Name == "redelivery_count_greater_than" &&
                                      (int) parameter.Value == redeliveryCountGreaterThan) &&
                list.Any(parameter => parameter.Name == "redelivery_count_less_than" &&
                                      (int) parameter.Value == redeliveryCountLessThan) &&
                list.Any(parameter => parameter.Name == "redeemed_date_greater_than" &&
                                      (string) parameter.Value == redeemedDateGreaterThan) &&
                list.Any(parameter => parameter.Name == "redeemed_date_less_than" &&
                                      (string) parameter.Value == redeemedDateLessThan) &&
                list.Any(parameter => parameter.Name == "limit" && (int) parameter.Value == limit) &&
                list.Any(parameter => parameter.Name == "offset" && (int) parameter.Value == offset) &&
                list.Any(parameter => parameter.Name == "sort" && (string) parameter.Value == sort) &&
                list.Any(parameter => parameter.Name == "order" && (string) parameter.Value == order)
            );

            await factory.Received()
                .ExecuteRequest<ListGiftsResponse>("/gifts", parameters, token: CancellationToken.None);
        }


        [Fact]
        public async Task CorrectRequestForRetrieveGift()
        {
            var factory = Substitute.For<IConnection>();
            var client = new GiftsClient(factory);

            var fakeId = Guid.NewGuid().ToString();

            await client.RetrieveGift(fakeId, CancellationToken.None);

            await factory.Received()
                .ExecuteRequest<GiftResponse>($"/gifts/{fakeId}", token: CancellationToken.None);
        }

        [Fact]
        public async Task CorrectRequestForResendGift()
        {
            var factory = Substitute.For<IConnection>();
            var client = new GiftsClient(factory);

            var fakeId = Guid.NewGuid().ToString();
            var request = new ResendGiftRequest {Resend = true};

            await client.ResendGift(fakeId, request, CancellationToken.None);

            await factory.Received()
                .ExecuteRequest<GiftResponse>($"/gifts/{fakeId}", null, request, null, Method.PUT,
                    CancellationToken.None);
        }

        [Fact]
        public async Task CorrectRequestForCancelGift()
        {
            var factory = Substitute.For<IConnection>();
            var client = new GiftsClient(factory);

            var fakeId = Guid.NewGuid().ToString();

            await client.CancelGift(fakeId, CancellationToken.None);

            await factory.Received()
                .ExecuteRequest<GiftResponse>($"/gifts/{fakeId}", method: Method.DELETE, token: CancellationToken.None);
        }
    }
}