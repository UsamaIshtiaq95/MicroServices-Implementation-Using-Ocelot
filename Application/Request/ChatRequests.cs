using Application.DTO;
using MediatR;

namespace Application.Request;

// Chat Create
public class CreateChatRequest : IRequest<CreateChatResponse>
{
    public ChatCreateDto ChatDto { get; set; }
}

public class CreateChatResponse
{
    public ChatResponseDto Chat { get; set; }
    public string Message { get; set; }
}

// Chat Get All
public class GetAllChatsRequest : IRequest<GetAllChatsResponse>
{
}

public class GetAllChatsResponse
{
    public IEnumerable<ChatResponseDto> Chats { get; set; }
}

// Chat Get By Id
public class GetChatByIdRequest : IRequest<GetChatByIdResponse>
{
    public int Id { get; set; }
}

public class GetChatByIdResponse
{
    public ChatResponseDto Chat { get; set; }
}

// Chat Get By User Id
public class GetChatsByUserIdRequest : IRequest<GetChatsByUserIdResponse>
{
    public int UserId { get; set; }
}

public class GetChatsByUserIdResponse
{
    public IEnumerable<ChatResponseDto> Chats { get; set; }
}

// Chat Get By Room Id
public class GetChatsByRoomIdRequest : IRequest<GetChatsByRoomIdResponse>
{
    public int RoomId { get; set; }
}

public class GetChatsByRoomIdResponse
{
    public IEnumerable<ChatResponseDto> Chats { get; set; }
}

// Chat Update
public class UpdateChatRequest : IRequest<UpdateChatResponse>
{
    public int Id { get; set; }
    public ChatUpdateDto ChatDto { get; set; }
}

public class UpdateChatResponse
{
    public string Message { get; set; }
}

// Chat Delete
public class DeleteChatRequest : IRequest<DeleteChatResponse>
{
    public int Id { get; set; }
}

public class DeleteChatResponse
{
    public string Message { get; set; }
}
