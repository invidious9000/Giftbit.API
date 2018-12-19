using Newtonsoft.Json;

namespace Giftbit.API.Model.Request
{
    [JsonObject]
    public class AddFundsRequest
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("fund_amount_in_cents")] public long FundAmountInCents { get; set; }
        [JsonProperty("currencyisocode")] public string CurrencyIsoCode { get; set; }
    }
}