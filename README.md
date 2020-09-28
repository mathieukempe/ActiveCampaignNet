# ActiveCampaignNet
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Fmathieukempe%2FActiveCampaignNet.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2Fmathieukempe%2FActiveCampaignNet?ref=badge_shield)

ActiveCampaignNet is a .NET class library that provides an easy-to-use interface for the http://www.activecampaign.com/ web api

# Examples

## Initialization of the client 

```csharp
ActiveCampaignClient client = new ActiveCampaignClient("<You-api-key>", "https://some-url.api-us1.com");
```

## Adding a contact

```csharp
var client = new ActiveCampaignClient("<You-api-key>", "https://some-url.api-us1.com");

var result = client.Api("contact_add", new Dictionary<string, string>
 {
     {"email", "someemail@gmail.com"},
     {"first_name", "mathieu"},
     {"last_name", "kempe"},
     {"p[1]", "1"}
 });

 if (result.IsSuccessful)
 {
     Console.WriteLine(result.Message);
 }

```


## Lists List

```csharp
var result = client.Api("list_list", new Dictionary<string, string>
{
    {"ids", "all"}
});

if (result.IsSuccessful)
{
    Console.WriteLine(result.Data);
}
```


## License
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Fmathieukempe%2FActiveCampaignNet.svg?type=large)](https://app.fossa.com/projects/git%2Bgithub.com%2Fmathieukempe%2FActiveCampaignNet?ref=badge_large)