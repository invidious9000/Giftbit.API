using Newtonsoft.Json;

namespace Giftbit.API.Model.Request
{
    [JsonObject]
    public class ResendGiftRequest
    {
        //On a scale of 1-10, 10 being dumbest this ranks as: potato
        [JsonProperty("resend")] public bool Resend { get; set; } = true;
    }
}