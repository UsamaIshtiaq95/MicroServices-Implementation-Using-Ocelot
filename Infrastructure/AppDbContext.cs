
using Microsoft.EntityFrameworkCore;
using UserDomain.Entities;

namespace Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}


