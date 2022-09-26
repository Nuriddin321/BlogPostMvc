using BlogMvc.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogMvc.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public DbSet<Post> Posts { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
}