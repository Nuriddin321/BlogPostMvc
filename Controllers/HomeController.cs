using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BlogMvc.Models;
using Microsoft.AspNetCore.Authorization;
using BlogMvc.Data;
using BlogMvc.Services;

namespace BlogMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPostService _service;
    public HomeController(ILogger<HomeController> logger, IPostService service)
    {
        _logger = logger;
        _service = service;
    }


    public async Task<IActionResult> Index()
    {
        var posts = await _service.GetPostsAsync();
        return View(posts.Reverse());
    }

    [Authorize]
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
