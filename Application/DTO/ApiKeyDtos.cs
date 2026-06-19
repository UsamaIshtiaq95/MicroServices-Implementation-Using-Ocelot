namespace Application.DTO;

public class ApiKeyCreateDto
{
    public string ServiceName { get; set; }
    public string Key { get; set; }
}

public class ApiKeyUpdateDto
{
    public string ServiceName { get; set; }
    public string Key { get; set; }
}

public class ApiKeyResponseDto
{
    public int ApiKeyId { get; set; }
    public string ServiceName { get; set; }
    public string Key { get; set; }
    public DateTime CreatedAt { get; set; }
}
