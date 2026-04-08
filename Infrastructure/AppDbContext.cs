
using Microsoft.EntityFrameworkCore;
using UserDomain.Entities;

namespace Infrastructure;

public class AppDbContext : DbContext
{
    //public DbSet<User> Users { get; set; } = null!;
    public DbSet<EntityModels> Users { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Context> Contexts { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<ChatMessage> ChatMessages { get; set; }
    public DbSet<Log> Logs { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<ApiKey> ApiKeys { get; set; }
    public DbSet<AIResult> AIResults { get; set; }


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}


