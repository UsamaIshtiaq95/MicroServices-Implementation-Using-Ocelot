
using System.ComponentModel.DataAnnotations;

namespace UserDomain.Entities;
public class Logs
{
    [Key]
    public int LogId { get; set; }

    public int? UserId { get; set; }
    public Users User { get; set; }

    [MaxLength(500)]
    public string Action { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
