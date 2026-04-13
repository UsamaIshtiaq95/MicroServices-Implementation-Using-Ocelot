namespace Application.DTO;

public class ChatCreateDto
{
    public int RoomId { get; set; }
    public int UserId { get; set; }
    public int ContextId { get; set; }
}

public class ChatUpdateDto
{
    public int RoomId { get; set; }
    public int UserId { get; set; }
    public int ContextId { get; set; }
}

public class ChatResponseDto
{
    public int ChatId { get; set; }
    public int RoomId { get; set; }
    public string RoomName { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; }
    public int ContextId { get; set; }
    public DateTime CreatedAt { get; set; }
}
