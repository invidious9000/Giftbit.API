# Giftbit API Client
This package targets .NET Standard 2.0 and provides clients for Giftbit API v1.

# Install
TODO: Determine package name and repo location, update project properties and then update this part of the readme.md
Nuget> Install-Package Giftbit.API

# Usage
```
var client = new GiftbitClient("MY_API_TOKEN", GiftbitClient.ProductionUrl);
var pingResponse = await client.Ping.Ping(CancellationToken.None);
```

```
var client = new GiftbitClient("MY_API_TOKEN", GiftbitClient.ProductionUrl);
var myCampaignGifts = await client.Gifts.ListGifts(campaignId: "myCampaign", token: CancellationToken.None);
```

# Contributing
Test coverage is in xunit and currently only asserts request sanity and makes no guarantees about response content - these tests could be expanded upon. 