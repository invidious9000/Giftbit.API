using System.Collections.Generic;

namespace Giftbit.API.Model
{
    public class Campaign
    {
        public string Message { get; set; }
        public string Subject { get; set; }
        public List<Contact> Contacts { get; set; }
        public int PriceInCents { get; set; }
        public List<string> BrandCodes { get; set; }
        public string Status { get; set; }
        public string Uuid { get; set; }
        public string DeliveryType { get; set; }
        public string Expiry { get; set; }

        public int ContactSuccessCount { get; set; }
        public int ContactFailureCount { get; set; }

        public Fees Fees { get; set; }
        public string Id { get; set; }
    }

    public class Fees
    {
        public List<CostEntry> CostEntries { get; set; }
        public int SubtotalInCents { get; set; }
        public int TaxInCents { get; set; }
        public string TaxType { get; set; }
        public int TotalInCents { get; set; }
    }

    public class CostEntry
    {
        //Using double because API docs specify this entire object as 'string' type so falling back to assumption that it's a json double
        public double Percentage { get; set; }

        public string FeeType { get; set; }
        public int AmountInCents { get; set; }
        public string Currency { get; set; }
        public string TaxType { get; set; }
        public int TaxInCents { get; set; }
        public int NumberOfGifts { get; set; }
        public int FeePerGiftInCents { get; set; }
    }
}