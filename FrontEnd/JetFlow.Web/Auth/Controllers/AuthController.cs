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

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
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
            Request.Cookies.Append(new ("token-x",token));
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}