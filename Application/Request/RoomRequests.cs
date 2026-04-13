using Application.DTO;
using MediatR;

namespace Application.Request;

// Room Create
public class CreateRoomRequest : IRequest<CreateRoomResponse>
{
    public RoomCreateDto RoomDto { get; set; }
}

public class CreateRoomResponse
{
    public RoomResponseDto Room { get; set; }
    public string Message { get; set; }
}

// Room Get All
public class GetAllRoomsRequest : IRequest<GetAllRoomsResponse>
{
}

public class GetAllRoomsResponse
{
    public IEnumerable<RoomResponseDto> Rooms { get; set; }
}

// Room Get By Id
public class GetRoomByIdRequest : IRequest<GetRoomByIdResponse>
{
    public int Id { get; set; }
}

public class GetRoomByIdResponse
{
    public RoomResponseDto Room { get; set; }
}

// Room Update
public class UpdateRoomRequest : IRequest<UpdateRoomResponse>
{
    public int Id { get; set; }
    public RoomUpdateDto RoomDto { get; set; }
}

public class UpdateRoomResponse
{
    public string Message { get; set; }
}

// Room Delete
public class DeleteRoomRequest : IRequest<DeleteRoomResponse>
{
    public int Id { get; set; }
}

public class DeleteRoomResponse
{
    public string Message { get; set; }
}
