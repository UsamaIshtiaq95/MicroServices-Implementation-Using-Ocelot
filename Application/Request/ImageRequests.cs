using Application.DTO;
using MediatR;

namespace Application.Request;

// Image Create
public class CreateImageRequest : IRequest<CreateImageResponse>
{
    public ImageCreateDto ImageDto { get; set; }
}

public class CreateImageResponse
{
    public ImageResponseDto Image { get; set; }
    public string Message { get; set; }
}

// Image Get All
public class GetAllImagesRequest : IRequest<GetAllImagesResponse>
{
}

public class GetAllImagesResponse
{
    public IEnumerable<ImageResponseDto> Images { get; set; }
}

// Image Get By Id
public class GetImageByIdRequest : IRequest<GetImageByIdResponse>
{
    public int Id { get; set; }
}

public class GetImageByIdResponse
{
    public ImageResponseDto Image { get; set; }
}

// Image Get By Room Id
public class GetImagesByRoomIdRequest : IRequest<GetImagesByRoomIdResponse>
{
    public int RoomId { get; set; }
}

public class GetImagesByRoomIdResponse
{
    public IEnumerable<ImageResponseDto> Images { get; set; }
}

// Image Update
public class UpdateImageRequest : IRequest<UpdateImageResponse>
{
    public int Id { get; set; }
    public ImageUpdateDto ImageDto { get; set; }
}

public class UpdateImageResponse
{
    public string Message { get; set; }
}

// Image Delete
public class DeleteImageRequest : IRequest<DeleteImageResponse>
{
    public int Id { get; set; }
}

public class DeleteImageResponse
{
    public string Message { get; set; }
}
