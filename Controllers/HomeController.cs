using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EMG_website.Models;

namespace EMG_website.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SupabaseService _supabaseService;

    public HomeController(ILogger<HomeController> logger, SupabaseService supabaseService)
    {
        _logger = logger;
        _supabaseService = supabaseService;
    }


    public async Task<IActionResult> Index()
{
    var voitures = await _supabaseService.GetVoituresAsync();
    return View(voitures);
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
