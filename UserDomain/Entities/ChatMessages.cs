
using System.ComponentModel.DataAnnotations;

namespace UserDomain.Entities;

public class ChatMessages
{
    [Key]
    public int MessageId { get; set; }

    [Required]
    public int ChatId { get; set; }
    public Chats Chat { get; set; }

    [Required, MaxLength(50)]
    public string Sender { get; set; }  // "User" or "AI"

    [Required]
    public string MessageText { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
