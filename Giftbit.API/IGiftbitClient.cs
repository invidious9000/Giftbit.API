using Giftbit.API.Clients;

namespace Giftbit.API
{
    public interface IGiftbitClient
    {
        IPingClient Ping { get; }
        IBrandsClient Brands { get; }
        IRegionsClient Regions { get; }
        ICampaignClient Campaign { get; }
        IFundsClient Funds { get; }
        IGiftsClient Gifts { get; }
        ILinksClient Links { get; }
    }
}