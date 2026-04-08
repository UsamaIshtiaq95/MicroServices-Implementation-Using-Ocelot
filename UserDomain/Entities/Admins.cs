
using System.ComponentModel.DataAnnotations;

namespace UserDomain.Entities;

public class Admins
{
    [Key]
    public int AdminId { get; set; }

    [Required, MaxLength(100)]
    public string Username { get; set; }

    [Required, MaxLength(150)]
    public string Email { get; set; }

    [Required, MaxLength(500)]
    public string PasswordHash { get; set; }

    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
