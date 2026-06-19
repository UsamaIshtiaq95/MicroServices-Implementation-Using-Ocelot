
using System.ComponentModel.DataAnnotations;

namespace UserDomain.Entities;



public class Chats
{
    [Key]
    public int ChatId { get; set; }

    [Required]
    public int RoomId { get; set; }
    public Rooms Room { get; set; }

    [Required]
    public int UserId { get; set; }
    public Users User { get; set; }

    [Required]
    public int ContextId { get; set; }
    public Contexts Context { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public ICollection<ChatMessages> ChatMessages { get; set; }
    public ICollection<AIResults> AIResults { get; set; }
}
