using System.Text;
using System.Text.Json;
using JetFlow.Web.Auth.DTOs;
using JetFlow.Web.Auth.Interfaces;

namespace JetFlow.Web.Auth.Service;

public class ServiceAuth : IServiceAuth
{
    private const string NAME_CLIENT = "AuthClient";
    
    private readonly IHttpClientFactory _clientFactory;
    private readonly JsonSerializerOptions _options;

    public ServiceAuth(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};
    }
    
    public async Task<string?> Login(LoginDto model)
    {
        var client = _clientFactory.CreateClient(NAME_CLIENT);
        var content = new StringContent
            (JsonSerializer.Serialize(model), Encoding.UTF8,"application/json");
        using var resultOfRequest = await client.PostAsync("Auth/Login", content);
        if (!resultOfRequest.IsSuccessStatusCode) return null;

        var resultContent = await resultOfRequest.Content.ReadAsStreamAsync();
        var code = JsonSerializer.Deserialize<string>(resultContent);
        
        return await GetJwtFromAuthorizationCode(code!);
    }

    public async Task<string?> Register(RegisterDto model)
    {
        var client = _clientFactory.CreateClient(NAME_CLIENT);
        var content = new StringContent
            (JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
        using var resultOfRequest = await client.PostAsync("Auth/Cadastro", content);
        if (!resultOfRequest.IsSuccessStatusCode) return null;

        var resultContent = await resultOfRequest.Content.ReadAsStreamAsync();
        var code = JsonSerializer.Deserialize<string>(resultContent);

        return await GetJwtFromAuthorizationCode(code!);
    }

    private async Task<string?> GetJwtFromAuthorizationCode(string code)
    {
       
        var client = _clientFactory.CreateClient();
        var content = new StringContent
            (JsonSerializer.Serialize(code), Encoding.UTF8,"application/json");
        using var resultOfRequest = 
            await client.PostAsync("Auth/GetTokenOfAuthorizationCode", content);
        if (!resultOfRequest.IsSuccessStatusCode) return null;

        var resultContent = await resultOfRequest.Content.ReadAsStreamAsync();
        var jwt = JsonSerializer.Deserialize<string>(resultContent);
        return jwt;
    }
}