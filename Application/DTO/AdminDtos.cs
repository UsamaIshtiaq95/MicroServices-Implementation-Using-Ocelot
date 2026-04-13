namespace Application.DTO;

public class AdminCreateDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public bool IsActive { get; set; } = true;
}

public class AdminUpdateDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
}

public class AdminResponseDto
{
    public int AdminId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
}
