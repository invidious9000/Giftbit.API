using Newtonsoft.Json;

namespace Giftbit.API.Model
{
    [JsonObject]
    public class Brand
    {
        public string BrandCode { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        [JsonProperty(Required = Required.Default)]
        public string Disclaimer { get; set; }
    }
}