using Application.DTO;
using MediatR;

namespace Application.Request;

// ChatMessage Create
public class CreateChatMessageRequest : IRequest<CreateChatMessageResponse>
{
    public ChatMessageCreateDto ChatMessageDto { get; set; }
}

public class CreateChatMessageResponse
{
    public ChatMessageResponseDto ChatMessage { get; set; }
    public string Message { get; set; }
}

// ChatMessage Get All
public class GetAllChatMessagesRequest : IRequest<GetAllChatMessagesResponse>
{
}

public class GetAllChatMessagesResponse
{
    public IEnumerable<ChatMessageResponseDto> ChatMessages { get; set; }
}

// ChatMessage Get By Id
public class GetChatMessageByIdRequest : IRequest<GetChatMessageByIdResponse>
{
    public int Id { get; set; }
}

public class GetChatMessageByIdResponse
{
    public ChatMessageResponseDto ChatMessage { get; set; }
}

// ChatMessage Get By Chat Id
public class GetChatMessagesByChatIdRequest : IRequest<GetChatMessagesByChatIdResponse>
{
    public int ChatId { get; set; }
}

public class GetChatMessagesByChatIdResponse
{
    public IEnumerable<ChatMessageResponseDto> ChatMessages { get; set; }
}

// ChatMessage Update
public class UpdateChatMessageRequest : IRequest<UpdateChatMessageResponse>
{
    public int Id { get; set; }
    public ChatMessageUpdateDto ChatMessageDto { get; set; }
}

public class UpdateChatMessageResponse
{
    public string Message { get; set; }
}

// ChatMessage Delete
public class DeleteChatMessageRequest : IRequest<DeleteChatMessageResponse>
{
    public int Id { get; set; }
}

public class DeleteChatMessageResponse
{
    public string Message { get; set; }
}
