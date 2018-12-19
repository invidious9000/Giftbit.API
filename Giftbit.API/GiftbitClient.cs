using Giftbit.API.Clients;
using Giftbit.API.Clients.RestSharp;
using Giftbit.API.Http;
using RestSharp;
using RestSharp.Authenticators;

namespace Giftbit.API
{
    public class GiftbitClient:IGiftbitClient
    {
        public GiftbitClient(string apiToken, string apiUriRoot = "https://api-testbed.giftbit.com/papi/v1/")
        {
            var client = new RestClient(apiUriRoot)
            {
                Authenticator = new JwtAuthenticator(apiToken)
            };

            IConnection connection = new Connection(client);
            Ping = new PingClient(connection);
            Brands = new BrandsClient(connection);
            Regions = new RegionsClient(connection);
            Campaign = new CampaignClient(connection);
            Funds = new FundsClient(connection);
            Gifts = new GiftsClient(connection);
            Links = new LinksClient(connection);
        }

        public IPingClient Ping { get; }
        public IBrandsClient Brands { get; }
        public IRegionsClient Regions { get; }
        public ICampaignClient Campaign { get; }
        public IFundsClient Funds { get; }
        public IGiftsClient Gifts { get; }
        public ILinksClient Links { get; }
    }
}