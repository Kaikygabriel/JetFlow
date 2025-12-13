using JetFlow.Web.Product.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JetFlow.Web.Product.Controllers;

public class FlightController : Controller
{
    private readonly IServiceFlight _flightService;

    public FlightController(IServiceFlight flightService)
    {
        _flightService = flightService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index(int skip =0 , int take = 15)
        => View(await _flightService.GetAllAsync(skip,take));
    
}