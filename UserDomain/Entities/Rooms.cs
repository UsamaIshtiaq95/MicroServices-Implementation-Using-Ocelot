
using System.ComponentModel.DataAnnotations;

namespace UserDomain.Entities;
public class Rooms
{
    [Key]
    public int RoomId { get; set; }

    [Required, MaxLength(100)]
    public string RoomName { get; set; }

    [MaxLength(50)]
    public string RoomSize { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public ICollection<Chats> Chats { get; set; }
    public ICollection<Images> Images { get; set; }
}
