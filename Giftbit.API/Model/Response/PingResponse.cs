using Newtonsoft.Json;

namespace Giftbit.API.Model.Response
{
    public class PingResponse
    {
        [JsonProperty("username")] public string Username { get; set; }
        [JsonProperty("displayname")] public string DisplayName { get; set; }
        public ResponseInfo Info { get; set; }

        public override string ToString()
        {
            return $"{nameof(DisplayName)}: {DisplayName}, {nameof(Info)}: {Info}, {nameof(Username)}: {Username}";
        }
    }
}