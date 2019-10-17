# ActiveCampaignNet
ActiveCampaignNet is a .NET class library that provides an easy-to-use interface for the http://www.activecampaign.com/ web api

# Examples

## Initialization of the client 

```csharp
ActiveCampaignClient client = new ActiveCampaignClient("<You-api-key>", "https://some-url.api-us1.com");
```

## Adding a contact

```csharp
// define client
var client = new ActiveCampaignClient("<You-api-key>", "https://some-url.api-us1.com");

// create async method
public static async void AddContact() {
  var result = await client.ApiAsync("contact_add", new Dictionary<string, string>
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
}


```


## Lists List

```csharp
public static async void GetList() {
  var result = await client.ApiAsync("list_list", new Dictionary<string, string>
  {
      {"ids", "all"}
  });

  if (result.IsSuccessful)
  {
      Console.WriteLine(result.Data);
  }
}

```
