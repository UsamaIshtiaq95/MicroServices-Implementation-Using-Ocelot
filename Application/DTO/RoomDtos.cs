namespace Application.DTO;

public class RoomCreateDto
{
    public string RoomName { get; set; }
    public string RoomSize { get; set; }
}

public class RoomUpdateDto
{
    public string RoomName { get; set; }
    public string RoomSize { get; set; }
}

public class RoomResponseDto
{
    public int RoomId { get; set; }
    public string RoomName { get; set; }
    public string RoomSize { get; set; }
    public DateTime CreatedAt { get; set; }
}
