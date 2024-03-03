using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EMG_website.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace EMG_website.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(User user, string returnUrl)
    {
        if (user.Username == "admin" && user.Password == "passer")
        {
            //print in console
            Console.WriteLine("User is logged in");

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username)
        };

            var identity = new ClaimsIdentity(claims, "CookieAuth");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("CookieAuth", principal);

            return RedirectToAction("Index", "Dashboard");
        }

        ModelState.AddModelError(string.Empty, "Les identifiants sont incorrects.");
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("CookieAuth");
        return RedirectToAction("Login");
    }

}
