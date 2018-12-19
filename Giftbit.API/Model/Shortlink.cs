using Newtonsoft.Json;

namespace Giftbit.API.Model
{
    public class Shortlink
    {
        public int Number { get; set; }
        [JsonProperty("shortlink")] public string ShortLink { get; set; }
    }
}