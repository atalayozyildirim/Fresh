using Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class Context: IdentityDbContext<Users>
{
    public Context(DbContextOptions<Context> options): base(options)
    {
    }
    public DbSet<Post> Post { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Likes> Likes { get; set; }
}