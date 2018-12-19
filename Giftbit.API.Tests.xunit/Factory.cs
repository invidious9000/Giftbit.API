using System;

namespace Giftbit.API.Tests.xunit
{
    public static class Factory
    {
        public static IGiftbitClient GetClient()
        {
            return new GiftbitClient(Environment.GetEnvironmentVariable("GIFTBIT_API_TOKEN"),
                Environment.GetEnvironmentVariable("GIFTBIT_API_URL"));
        }
    }
}