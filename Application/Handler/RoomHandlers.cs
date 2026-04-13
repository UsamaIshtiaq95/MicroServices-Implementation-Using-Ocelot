using Application.DTO;
using Application.Request;
using MediatR;
using UserDomain;
using UserDomain.Entities;
using UserDomain.Interface;

namespace Application.Handler;

public class CreateRoomHandler : IRequestHandler<CreateRoomRequest, CreateRoomResponse>
{
    private readonly IRoomRepository _roomRepository;

    public CreateRoomHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<CreateRoomResponse> Handle(CreateRoomRequest request, CancellationToken cancellationToken)
    {
        var room = new Rooms
        {
            RoomName = request.RoomDto.RoomName,
            RoomSize = request.RoomDto.RoomSize,
            CreatedAt = DateTime.Now
        };

        var createdRoom = await _roomRepository.AddAsync(room);

        return new CreateRoomResponse
        {
            Room = new RoomResponseDto
            {
                RoomId = createdRoom.RoomId,
                RoomName = createdRoom.RoomName,
                RoomSize = createdRoom.RoomSize,
                CreatedAt = createdRoom.CreatedAt
            },
            Message = "Room created successfully"
        };
    }
}

public class GetAllRoomsHandler : IRequestHandler<GetAllRoomsRequest, GetAllRoomsResponse>
{
    private readonly IRoomRepository _roomRepository;

    public GetAllRoomsHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<GetAllRoomsResponse> Handle(GetAllRoomsRequest request, CancellationToken cancellationToken)
    {
        var rooms = await _roomRepository.GetAllAsync();

        var roomDtos = rooms.Select(r => new RoomResponseDto
        {
            RoomId = r.RoomId,
            RoomName = r.RoomName,
            RoomSize = r.RoomSize,
            CreatedAt = r.CreatedAt
        });

        return new GetAllRoomsResponse { Rooms = roomDtos };
    }
}

public class GetRoomByIdHandler : IRequestHandler<GetRoomByIdRequest, GetRoomByIdResponse>
{
    private readonly IRoomRepository _roomRepository;

    public GetRoomByIdHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<GetRoomByIdResponse> Handle(GetRoomByIdRequest request, CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetByIdAsync(request.Id);

        if (room == null)
            throw new NotFoundException("Room not found");

        return new GetRoomByIdResponse
        {
            Room = new RoomResponseDto
            {
                RoomId = room.RoomId,
                RoomName = room.RoomName,
                RoomSize = room.RoomSize,
                CreatedAt = room.CreatedAt
            }
        };
    }
}

public class UpdateRoomHandler : IRequestHandler<UpdateRoomRequest, UpdateRoomResponse>
{
    private readonly IRoomRepository _roomRepository;

    public UpdateRoomHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<UpdateRoomResponse> Handle(UpdateRoomRequest request, CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetByIdAsync(request.Id);

        if (room == null)
            throw new NotFoundException("Room not found");

        room.RoomName = request.RoomDto.RoomName;
        room.RoomSize = request.RoomDto.RoomSize;

        await _roomRepository.UpdateAsync(room);

        return new UpdateRoomResponse { Message = "Room updated successfully" };
    }
}

public class DeleteRoomHandler : IRequestHandler<DeleteRoomRequest, DeleteRoomResponse>
{
    private readonly IRoomRepository _roomRepository;

    public DeleteRoomHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<DeleteRoomResponse> Handle(DeleteRoomRequest request, CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetByIdAsync(request.Id);

        if (room == null)
            throw new NotFoundException("Room not found");

        await _roomRepository.DeleteAsync(request.Id);

        return new DeleteRoomResponse { Message = "Room deleted successfully" };
    }
}
