namespace Application.DTO;

public class LogCreateDto
{
    public int? UserId { get; set; }
    public string Action { get; set; }
}

public class LogUpdateDto
{
    public string Action { get; set; }
}

public class LogResponseDto
{
    public int LogId { get; set; }
    public int? UserId { get; set; }
    public string UserName { get; set; }
    public string Action { get; set; }
    public DateTime CreatedAt { get; set; }
}
