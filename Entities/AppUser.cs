using Microsoft.AspNetCore.Identity;

namespace BlogMvc.Entities;

public class AppUser : IdentityUser
{
    public string Avatar { get; set; }
    public virtual ICollection<Post> Posts { get; set; }
}