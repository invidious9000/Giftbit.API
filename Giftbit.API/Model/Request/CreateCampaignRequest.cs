using System.Collections.Generic;
using Newtonsoft.Json;

namespace Giftbit.API.Model.Request
{
    [JsonObject]
    public class CreateCampaignRequest
    {
        [JsonProperty("gift_template")] public string GiftTemplate { get; set; }
        [JsonProperty("contacts")] public List<Contact> Contacts { get; set; }
        [JsonProperty("price_in_cents")] public int PriceInCents { get; set; }
        [JsonProperty("brand_codes")] public List<string> BrandCodes { get; set; }
        [JsonProperty("expiry")] public string Expiry { get; set; }
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("message")] public string Message { get; set; }
        [JsonProperty("subject")] public string Subject { get; set; }
        [JsonProperty("delivery_type")] public string DeliveryType { get; set; }
        [JsonProperty("link_count")] public int? LinkCount { get; set; }
    }
}