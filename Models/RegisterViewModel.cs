namespace BlogMvc.Models;

public class RegisterViewModel
{
    public string Username { get; set; }
    public string Password { get; set; }
    public IFormFile Avatar { get; set; }
    public string ReturnUrl { get; set; }
}