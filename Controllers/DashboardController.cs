using EMG_website.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class DashboardController : Controller
{
    private readonly SupabaseService _supabaseService;

    public DashboardController(SupabaseService supabaseService)
    {
        _supabaseService = supabaseService;
    }

    public async Task<IActionResult> Index()
    {
        var voitures = await _supabaseService.GetVoituresAsync();
        return View(voitures);
    }

    [HttpPost]
    public async Task<IActionResult> InsertVoiture(Voiture voiture)
    {
        await _supabaseService.InsertVoitureAsync(voiture);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> UpdateVoiture(Voiture voiture)
    {
        await _supabaseService.UpdateVoitureAsync(voiture);
        return RedirectToAction("Index");
    }

    [HttpPost]
    [HttpPost]
    public async Task<IActionResult> DeleteVoiture(int id)
    {
        await _supabaseService.DeleteVoitureAsync(new Voiture { Id = id });
        return RedirectToAction("Index");
    }




}
