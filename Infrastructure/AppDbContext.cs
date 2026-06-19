
using Microsoft.EntityFrameworkCore;
using UserDomain.Entities;

namespace Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<Users> Users { get; set; } = null!;
    //public DbSet<Users> Users { get; set; }
    public DbSet<Admins> Admins { get; set; }
    public DbSet<Rooms> Rooms { get; set; }
    public DbSet<Contexts> Contexts { get; set; }
    public DbSet<Chats> Chats { get; set; }
    public DbSet<ChatMessages> ChatMessages { get; set; }
    public DbSet<Logs> Logs { get; set; }
    public DbSet<Images> Images { get; set; }
    public DbSet<ApiKeys> ApiKeys { get; set; }
    public DbSet<AIResults> AIResults { get; set; }


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}


