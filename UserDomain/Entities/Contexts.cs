
using System.ComponentModel.DataAnnotations;

namespace UserDomain.Entities;


public class Contexts
{
    [Key]
    public int ContextId { get; set; }

    [Required]
    public int RoomCount { get; set; }

    public string ContextData { get; set; }

    [MaxLength(50)]
    public string SourceAI { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
