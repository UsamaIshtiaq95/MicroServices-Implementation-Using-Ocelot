namespace Application.DTO;

public class AIResultCreateDto
{
    public int ChatId { get; set; }
    public string AIResponse { get; set; }
    public string AIUsed { get; set; }
}

public class AIResultUpdateDto
{
    public string AIResponse { get; set; }
    public string AIUsed { get; set; }
}

public class AIResultResponseDto
{
    public int ResultId { get; set; }
    public int ChatId { get; set; }
    public string AIResponse { get; set; }
    public string AIUsed { get; set; }
    public DateTime CreatedAt { get; set; }
}
