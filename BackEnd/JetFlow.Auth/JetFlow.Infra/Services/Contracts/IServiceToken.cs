using System.Security.Claims;
using JetFlow.Domain.BackOffice.Entities;

namespace JetFlow.Infra.Services.Contracts;

public interface IServiceToken
{
     string GenerateAccessToken(IEnumerable<Claim>claims);
     string GenerateAuthenticationCode(string emailUser);
     string? GetEmailUserOfAuthenticationCodeOrNull(string code);
     
}