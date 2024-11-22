using System.Security.Claims;
using App.Models;
using App.Services;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

public class AuthController(AuthService authService) : Controller
{
    private readonly AuthService _authService = authService;

    public async Task<IActionResult> Profile()
    {
        var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var user = await _authService.GetUserAsync(id ?? "");
        if (user is null)
        {
            return RedirectToAction("Register");
        }

        return View(user);
    }

    public IActionResult Register()
    {
        return View();
    }

    public async Task Login()
    {
        string returnUrl = "/";
        var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
            .WithRedirectUri(returnUrl)
            .Build();

        await HttpContext.ChallengeAsync(
            Auth0Constants.AuthenticationScheme,
            authenticationProperties
        );
    }

    [HttpPost]
    public async Task<IActionResult> Register(SignUpViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var result = await _authService.CreateUserAsync(model);
        if (!result)
        {
            ModelState.AddModelError(string.Empty, "Failed to create user");
            return View(model);
        }

        return RedirectToAction("Index", "Home");
    }

    [Authorize]
    public async Task Logout()
    {
        var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
            .WithRedirectUri(Url.Action("Index", "Home")!)
            .Build();

        await HttpContext.SignOutAsync(
            Auth0Constants.AuthenticationScheme,
            authenticationProperties
        );

        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
}
