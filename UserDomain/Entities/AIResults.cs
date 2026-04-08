
using System.ComponentModel.DataAnnotations;
using UserDomain.Entities;


public class AIResults
{
    [Key]
    public int ResultId { get; set; }

    [Required]
    public int ChatId { get; set; }
    public Chats Chat { get; set; }

    public string AIResponse { get; set; }

    [MaxLength(50)]
    public string AIUsed { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

