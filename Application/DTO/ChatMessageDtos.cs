namespace Application.DTO;

public class ChatMessageCreateDto
{
    public int ChatId { get; set; }
    public string Sender { get; set; }
    public string MessageText { get; set; }
}

public class ChatMessageUpdateDto
{
    public string MessageText { get; set; }
}

public class ChatMessageResponseDto
{
    public int MessageId { get; set; }
    public int ChatId { get; set; }
    public string Sender { get; set; }
    public string MessageText { get; set; }
    public DateTime CreatedAt { get; set; }
}
