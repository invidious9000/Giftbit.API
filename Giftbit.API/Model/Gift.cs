namespace Giftbit.API.Model
{
    public class Gift
    {
        public string Uuid { get; set; }
        public string CampaignUuid { get; set; }
        public string DeliveryStatus { get; set; }
        public string ManagementDashboardLink { get; set; }
        public int RedeliveryCount { get; set; }
        public string CampaignId { get; set; }
        public long PriceInCents { get; set; }
        public string BrandCode { get; set; }
        public string CreatedDate { get; set; }
        public string DeliveryDate { get; set; }
        public string Shortlink { get; set; }
    }
}