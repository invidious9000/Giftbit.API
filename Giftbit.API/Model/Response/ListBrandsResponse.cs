using System.Collections.Generic;
using Newtonsoft.Json;

namespace Giftbit.API.Model.Response
{
    [JsonObject]
    public class ListBrandsResponse
    {
        [JsonProperty("brands")] public List<Brand> Brands { get; set; }
        public int TotalCount { get; set; }
        public ResponseInfo Info { get; set; }
        public int NumberOfResults { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
    }
}