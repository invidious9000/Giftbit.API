using System;

namespace Giftbit.API.Tests
{
   public static class Factory
    {
        public static IGiftbitClient GetClient()
        {
            return new GiftbitClient(Environment.GetEnvironmentVariable("DIGITALOCEAN_API_KEY"));
        }
    }
}
