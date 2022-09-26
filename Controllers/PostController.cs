using BlogMvc.Entities;
using BlogMvc.Models;
using BlogMvc.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogMvc.Controllers;

[Authorize]
public class PostController : Controller
{
    private readonly ILogger<PostController> _logger;
    private readonly IPostService _service;
    private readonly UserManager<AppUser> _userManager;

    public PostController(
        ILogger<PostController> logger,
        IPostService service,
        UserManager<AppUser> userManager
    )
    {
        _logger = logger;
        _service = service;
        _userManager = userManager;
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrUpdateViewModel model)
    {
        if(!ModelState.IsValid) return View();
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        var post = await _service.CreatePostAsync(model, user.Id);
        return LocalRedirect($"/home/index/{post.Id}");
    }

    public async Task<IActionResult> Article([FromRoute]long id)
    {
        var post = await _service.GetPostAsync(id);
        return View(post);
    }
}