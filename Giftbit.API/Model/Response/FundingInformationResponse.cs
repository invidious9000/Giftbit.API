using System.Collections.Generic;
using Newtonsoft.Json;

namespace Giftbit.API.Model.Response
{
    public class FundingInformationResponse
    {
        public ResponseInfo Info { get; set; }
        [JsonProperty("fundsbycurrency")] public Dictionary<string, Fund> FundsByCurrency { get; set; }
    }

    public class Fund
    {
        public long AvailableInCents { get; set; }
        public long PendingInCents { get; set; }
        public long ReservedInCents { get; set; }
    }
}