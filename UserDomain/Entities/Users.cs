
using System.ComponentModel.DataAnnotations;

namespace UserDomain.Entities;



public class Users
{
    [Key]
    public int UserId { get; set; }

    [Required, MaxLength(100)]
    public string Username { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; }

    [Required, MaxLength(150)]
    public string Email { get; set; }

    [Required, MaxLength(500)]
    public string PasswordHash { get; set; }

    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public ICollection<Chats> Chats { get; set; }
    public ICollection<Logs> Logs { get; set; }
}
