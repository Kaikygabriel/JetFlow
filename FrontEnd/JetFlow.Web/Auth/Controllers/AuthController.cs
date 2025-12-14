using JetFlow.Web.Auth.DTOs;
using JetFlow.Web.Auth.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JetFlow.Web.Auth.Controllers;

public class AuthController : Controller
{
    private readonly IServiceAuth _serviceAuth;

    public AuthController(IServiceAuth serviceAuth)
    {
        _serviceAuth = serviceAuth;
    }

    [HttpGet("Login")]
    public IActionResult Login()
    {
        if (IsConnected())
            return RedirectToAction("Index", "Home");
        return View();
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginDto model)
    {
        var token = await _serviceAuth.Login(model);
        if (token is null) return View(model);

        if (!AddTokenInCookies(token)) return View(model);

        return RedirectToAction("Index", "Home");   
    }

    private bool AddTokenInCookies(string token)
    {
        try
        {
            Response.Cookies.Append("token-x",token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,          
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddDays(3)
            });
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    private bool IsConnected()
    {
        Request.Cookies.TryGetValue("token-x",out var token);
        return token is not null ? true : false;
    }
}