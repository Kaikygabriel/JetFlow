using System.Text.Json;
using JetFlow.Web.Product.Entitie;
using JetFlow.Web.Product.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace JetFlow.Web.Product.Services;

public class ServiceFlight : IServiceFlight
{
    private const string NAME_CLIENT = "ProductClient";
    
    private readonly IHttpClientFactory _clientFactory;
    private readonly JsonSerializerOptions _options;

    public ServiceFlight(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};
    }

    public async Task<IEnumerable<Flight>?> GetAllAsync(int skip, int take)
    {
        var client = _clientFactory.CreateClient(NAME_CLIENT);
        using var result = await client.GetAsync($"Flight?skip={skip}&take={take}");
        if (!result.IsSuccessStatusCode) return null;
        var content = await result.Content.ReadAsStreamAsync();
        var flights = JsonSerializer.Deserialize<IEnumerable<Flight>>
            (content, _options);
        return flights;
    }

    public Task Create(Flight flight)
    {
        throw new NotImplementedException();
    }
}