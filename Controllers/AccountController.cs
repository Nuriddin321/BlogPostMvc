using BlogMvc.Entities;
using BlogMvc.Mapper;
using BlogMvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogMvc.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public AccountController(
        ILogger<AccountController> logger,
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager        
    )
    {
        _logger = logger;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Register(string returnUrl) => View(new RegisterViewModel() { ReturnUrl = returnUrl });

    public IActionResult Login(string returnUrl) => View(new LoginViewModel() { ReturnUrl = returnUrl });

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if(!ModelState.IsValid) return View(model);

        var user = model.ToEntity();

        var result = await _userManager.CreateAsync(user, model.Password);

        if(!result.Succeeded) return View(model);

        return LocalRedirect($"/account/login?returnUrl={model.ReturnUrl}");
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if(!ModelState.IsValid) return View(model);

        var user = await _userManager.FindByNameAsync(model.Username);

        if(user == null) return View(model);

        var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

        if(!result.Succeeded)
        {
            return View(model);
        }

        return LocalRedirect($"{model.ReturnUrl ?? "/"}");
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction(nameof(Login));
    }
}