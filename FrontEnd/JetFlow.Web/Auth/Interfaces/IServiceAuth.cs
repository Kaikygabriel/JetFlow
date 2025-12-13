using JetFlow.Web.Auth.DTOs;

namespace JetFlow.Web.Auth.Interfaces;

public interface IServiceAuth
{
    Task<string?> Login(LoginDto model);
    Task<string?> Register(RegisterDto model);
}