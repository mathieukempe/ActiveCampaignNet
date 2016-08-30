# ActiveCampaignNet
ActiveCampaignNet is a .NET class library that provides an easy-to-use interface for the http://www.activecampaign.com/ web api

# Examples

## Initialization of the client 

```csharp
ActiveCampaignClient client = new ActiveCampaignClient("<You-api-key>", "https://some-url.api-us1.com");
```

## Adding a contact

```csharp
var client = new ActiveCampaignClient("<You-api-key>", "https://some-url.api-us1.com");

var result = client.Api("contact_add", new NameValueCollection
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
var result = client.Api("list_list", new NameValueCollection
{
    {"ids", "all"}
});

if (result.IsSuccessful)
{
    Console.WriteLine(result.Data);
}
```
