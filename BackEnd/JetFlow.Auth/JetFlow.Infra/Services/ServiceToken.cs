using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using JetFlow.Domain.BackOffice.Entities;
using JetFlow.Domain.BackOffice.Interfaces;
using JetFlow.Infra.Services.Contracts;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace JetFlow.Infra.Services;

public class ServiceToken : IServiceToken
{
    private readonly IConfiguration _configuration;
    private readonly IMemoryCache _cache;

    public ServiceToken(IConfiguration configuration, IMemoryCache cache)
    {
        _configuration = configuration;
        _cache = cache;
    }

    public string GenerateAccessToken(IEnumerable<Claim> claims)
    {
        var rsa = RSA.Create();
        rsa.ImportFromPem(_configuration["Jwt:PrivateKey"]!);
        var credentials = new SigningCredentials(
            new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256);
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new(claims),
            Expires = DateTime.UtcNow.AddDays(3),
            SigningCredentials = credentials
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string GenerateAuthenticationCode(string emailUser)
    {
        var code = Guid.NewGuid().ToString("N");
        var optionsCache = new MemoryCacheEntryOptions()
        {
            Priority = CacheItemPriority.Normal,
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(3),
            Size = 1,
        };
        _cache.Set(code, emailUser, optionsCache);
        return code;
    }

    public string? GetEmailUserOfAuthenticationCodeOrNull(string code)
    {
        if(!_cache.TryGetValue(code, out string? userEmail))
            return null;
        
        return userEmail;
    }
}