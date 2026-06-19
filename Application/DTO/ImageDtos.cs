namespace Application.DTO;

public class ImageCreateDto
{
    public int? RoomId { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
}

public class ImageUpdateDto
{
    public int? RoomId { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
}

public class ImageResponseDto
{
    public int ImageId { get; set; }
    public int? RoomId { get; set; }
    public string RoomName { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public DateTime UploadedAt { get; set; }
}
