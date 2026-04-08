
using System.ComponentModel.DataAnnotations;

namespace UserDomain.Entities;



public class EntityModels
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

    public ICollection<Chat> Chats { get; set; }
    public ICollection<Log> Logs { get; set; }
}

public class Admin
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

public class Room
{
    [Key]
    public int RoomId { get; set; }

    [Required, MaxLength(100)]
    public string RoomName { get; set; }

    [MaxLength(50)]
    public string RoomSize { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public ICollection<Chat> Chats { get; set; }
    public ICollection<Image> Images { get; set; }
}

public class Context
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

public class Chat
{
    [Key]
    public int ChatId { get; set; }

    [Required]
    public int RoomId { get; set; }
    public Room Room { get; set; }

    [Required]
    public int UserId { get; set; }
    public EntityModels User { get; set; }

    [Required]
    public int ContextId { get; set; }
    public Context Context { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public ICollection<ChatMessage> ChatMessages { get; set; }
    public ICollection<AIResult> AIResults { get; set; }
}

public class ChatMessage
{
    [Key]
    public int MessageId { get; set; }

    [Required]
    public int ChatId { get; set; }
    public Chat Chat { get; set; }

    [Required, MaxLength(50)]
    public string Sender { get; set; }  // "User" or "AI"

    [Required]
    public string MessageText { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

public class Log
{
    [Key]
    public int LogId { get; set; }

    public int? UserId { get; set; }
    public EntityModels User { get; set; }

    [MaxLength(500)]
    public string Action { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

public class Image
{
    [Key]
    public int ImageId { get; set; }

    public int? RoomId { get; set; }
    public Room Room { get; set; }

    [Required, MaxLength(255)]
    public string FileName { get; set; }

    [Required, MaxLength(500)]
    public string FilePath { get; set; }

    public DateTime UploadedAt { get; set; } = DateTime.Now;
}

public class ApiKey
{
    [Key]
    public int ApiKeyId { get; set; }

    [Required, MaxLength(100)]
    public string ServiceName { get; set; }

    [Required, MaxLength(500)]
    public string Key { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

public class AIResult
{
    [Key]
    public int ResultId { get; set; }

    [Required]
    public int ChatId { get; set; }
    public Chat Chat { get; set; }

    public string AIResponse { get; set; }

    [MaxLength(50)]
    public string AIUsed { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

