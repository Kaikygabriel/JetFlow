using System.Security.Claims;
using JetFlow.Domain.BackOffice.Entities;
using JetFlow.Domain.BackOffice.Interfaces;
using JetFlow.Infra.Services.Contracts;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace JetFlow.Infra.Services;

public class ServiceToken : IServiceToken
{
    private IunitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;
    private readonly IMemoryCache _cache;

    public ServiceToken(IConfiguration configuration, IMemoryCache cache, IunitOfWork unitOfWork)
    {
        _configuration = configuration;
        _cache = cache;
        _unitOfWork = unitOfWork;
    }

    public string GenerateAccessToken(IEnumerable<Claim> claims)
    {
        throw new NotImplementedException();
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