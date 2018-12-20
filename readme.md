# Giftbit API Client
This package targets .NET Standard 2.0 and provides clients for Giftbit API v1.

# Install
TODO: Determine package name and repo location, update project properties and then update this part of the readme.md
Nuget> Install-Package Giftbit.API

# Usage
The client requires an API token and API URL. Both testbed and production URLs are included as constants for convenience.

```
var client = new GiftbitClient("TEST_API_TOKEN", GiftbitClient.TestbedUrl);
var pingResponse = await client.Ping.Ping(CancellationToken.None);
```

List responses will contain the list of entities returned as well as some additional details.
```
var client = new GiftbitClient("PROD_API_TOKEN", GiftbitClient.ProductionUrl);
var myCampaignGiftsResponse = await client.Gifts.ListGifts(campaignId: "myCampaign", token: CancellationToken.None);

//Display additional response details
Console.WriteLine($"ResponseInfo: {myCampaignGiftsResponse.Info}");

//Iterate through gifts
foreach (var gift in myCampaignGiftsResponse.Gifts) 
{
	Console.WriteLine($"Gift details: {gift}");
}
```

# TODO
Test coverage is in xunit and currently only asserts request sanity and makes no guarantees about response content - these tests could be expanded upon. 
Pagination could be handled automatically