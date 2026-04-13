using Application.DTO;
using Application.Request;
using MediatR;
using UserDomain;
using UserDomain.Entities;
using UserDomain.Interface;

namespace Application.Handler;

public class CreateChatHandler : IRequestHandler<CreateChatRequest, CreateChatResponse>
{
    private readonly IChatRepository _chatRepository;

    public CreateChatHandler(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }

    public async Task<CreateChatResponse> Handle(CreateChatRequest request, CancellationToken cancellationToken)
    {
        var chat = new Chats
        {
            RoomId = request.ChatDto.RoomId,
            UserId = request.ChatDto.UserId,
            ContextId = request.ChatDto.ContextId,
            CreatedAt = DateTime.Now
        };

        var createdChat = await _chatRepository.AddAsync(chat);

        return new CreateChatResponse
        {
            Chat = new ChatResponseDto
            {
                ChatId = createdChat.ChatId,
                RoomId = createdChat.RoomId,
                UserId = createdChat.UserId,
                ContextId = createdChat.ContextId,
                CreatedAt = createdChat.CreatedAt
            },
            Message = "Chat created successfully"
        };
    }
}

public class GetAllChatsHandler : IRequestHandler<GetAllChatsRequest, GetAllChatsResponse>
{
    private readonly IChatRepository _chatRepository;

    public GetAllChatsHandler(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }

    public async Task<GetAllChatsResponse> Handle(GetAllChatsRequest request, CancellationToken cancellationToken)
    {
        var chats = await _chatRepository.GetAllAsync();

        var chatDtos = chats.Select(c => new ChatResponseDto
        {
            ChatId = c.ChatId,
            RoomId = c.RoomId,
            UserId = c.UserId,
            ContextId = c.ContextId,
            CreatedAt = c.CreatedAt
        });

        return new GetAllChatsResponse { Chats = chatDtos };
    }
}

public class GetChatByIdHandler : IRequestHandler<GetChatByIdRequest, GetChatByIdResponse>
{
    private readonly IChatRepository _chatRepository;

    public GetChatByIdHandler(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }

    public async Task<GetChatByIdResponse> Handle(GetChatByIdRequest request, CancellationToken cancellationToken)
    {
        var chat = await _chatRepository.GetByIdAsync(request.Id);

        if (chat == null)
            throw new NotFoundException("Chat not found");

        return new GetChatByIdResponse
        {
            Chat = new ChatResponseDto
            {
                ChatId = chat.ChatId,
                RoomId = chat.RoomId,
                UserId = chat.UserId,
                ContextId = chat.ContextId,
                CreatedAt = chat.CreatedAt
            }
        };
    }
}

public class GetChatsByUserIdHandler : IRequestHandler<GetChatsByUserIdRequest, GetChatsByUserIdResponse>
{
    private readonly IChatRepository _chatRepository;

    public GetChatsByUserIdHandler(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }

    public async Task<GetChatsByUserIdResponse> Handle(GetChatsByUserIdRequest request, CancellationToken cancellationToken)
    {
        var chats = await _chatRepository.GetByUserIdAsync(request.UserId);

        var chatDtos = chats.Select(c => new ChatResponseDto
        {
            ChatId = c.ChatId,
            RoomId = c.RoomId,
            UserId = c.UserId,
            ContextId = c.ContextId,
            CreatedAt = c.CreatedAt
        });

        return new GetChatsByUserIdResponse { Chats = chatDtos };
    }
}

public class GetChatsByRoomIdHandler : IRequestHandler<GetChatsByRoomIdRequest, GetChatsByRoomIdResponse>
{
    private readonly IChatRepository _chatRepository;

    public GetChatsByRoomIdHandler(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }

    public async Task<GetChatsByRoomIdResponse> Handle(GetChatsByRoomIdRequest request, CancellationToken cancellationToken)
    {
        var chats = await _chatRepository.GetByRoomIdAsync(request.RoomId);

        var chatDtos = chats.Select(c => new ChatResponseDto
        {
            ChatId = c.ChatId,
            RoomId = c.RoomId,
            UserId = c.UserId,
            ContextId = c.ContextId,
            CreatedAt = c.CreatedAt
        });

        return new GetChatsByRoomIdResponse { Chats = chatDtos };
    }
}

public class UpdateChatHandler : IRequestHandler<UpdateChatRequest, UpdateChatResponse>
{
    private readonly IChatRepository _chatRepository;

    public UpdateChatHandler(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }

    public async Task<UpdateChatResponse> Handle(UpdateChatRequest request, CancellationToken cancellationToken)
    {
        var chat = await _chatRepository.GetByIdAsync(request.Id);

        if (chat == null)
            throw new NotFoundException("Chat not found");

        chat.RoomId = request.ChatDto.RoomId;
        chat.UserId = request.ChatDto.UserId;
        chat.ContextId = request.ChatDto.ContextId;

        await _chatRepository.UpdateAsync(chat);

        return new UpdateChatResponse { Message = "Chat updated successfully" };
    }
}

public class DeleteChatHandler : IRequestHandler<DeleteChatRequest, DeleteChatResponse>
{
    private readonly IChatRepository _chatRepository;

    public DeleteChatHandler(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }

    public async Task<DeleteChatResponse> Handle(DeleteChatRequest request, CancellationToken cancellationToken)
    {
        var chat = await _chatRepository.GetByIdAsync(request.Id);

        if (chat == null)
            throw new NotFoundException("Chat not found");

        await _chatRepository.DeleteAsync(request.Id);

        return new DeleteChatResponse { Message = "Chat deleted successfully" };
    }
}
