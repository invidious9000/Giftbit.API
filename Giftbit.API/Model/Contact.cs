using Newtonsoft.Json;

namespace Giftbit.API.Model
{
    [JsonObject]
    public class Contact
    {
        [JsonProperty("email")] public string Email { get; set; }
        [JsonProperty("firstname")] public string FirstName { get; set; }
        [JsonProperty("lastname")] public string LastName { get; set; }
    }
}