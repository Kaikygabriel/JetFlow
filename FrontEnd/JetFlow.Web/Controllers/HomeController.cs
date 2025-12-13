using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JetFlow.Web.Models;
using JetFlow.Web.Product.Interfaces;

namespace JetFlow.Web.Controllers;

public class HomeController : Controller
{
    private readonly IServiceFlight _flight;

    public HomeController(IServiceFlight flight)
    {
        _flight = flight;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
