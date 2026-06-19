using Application.DTO;
using Application.Request;
using MediatR;
using UserDomain;
using UserDomain.Entities;
using UserDomain.Interface;

namespace Application.Handler;

public class CreateChatMessageHandler : IRequestHandler<CreateChatMessageRequest, CreateChatMessageResponse>
{
    private readonly IChatMessageRepository _chatMessageRepository;

    public CreateChatMessageHandler(IChatMessageRepository chatMessageRepository)
    {
        _chatMessageRepository = chatMessageRepository;
    }

    public async Task<CreateChatMessageResponse> Handle(CreateChatMessageRequest request, CancellationToken cancellationToken)
    {
        var chatMessage = new ChatMessages
        {
            ChatId = request.ChatMessageDto.ChatId,
            Sender = request.ChatMessageDto.Sender,
            MessageText = request.ChatMessageDto.MessageText,
            CreatedAt = DateTime.Now
        };

        var createdChatMessage = await _chatMessageRepository.AddAsync(chatMessage);

        return new CreateChatMessageResponse
        {
            ChatMessage = new ChatMessageResponseDto
            {
                MessageId = createdChatMessage.MessageId,
                ChatId = createdChatMessage.ChatId,
                Sender = createdChatMessage.Sender,
                MessageText = createdChatMessage.MessageText,
                CreatedAt = createdChatMessage.CreatedAt
            },
            Message = "Chat message created successfully"
        };
    }
}

public class GetAllChatMessagesHandler : IRequestHandler<GetAllChatMessagesRequest, GetAllChatMessagesResponse>
{
    private readonly IChatMessageRepository _chatMessageRepository;

    public GetAllChatMessagesHandler(IChatMessageRepository chatMessageRepository)
    {
        _chatMessageRepository = chatMessageRepository;
    }

    public async Task<GetAllChatMessagesResponse> Handle(GetAllChatMessagesRequest request, CancellationToken cancellationToken)
    {
        var chatMessages = await _chatMessageRepository.GetAllAsync();

        var chatMessageDtos = chatMessages.Select(cm => new ChatMessageResponseDto
        {
            MessageId = cm.MessageId,
            ChatId = cm.ChatId,
            Sender = cm.Sender,
            MessageText = cm.MessageText,
            CreatedAt = cm.CreatedAt
        });

        return new GetAllChatMessagesResponse { ChatMessages = chatMessageDtos };
    }
}

public class GetChatMessageByIdHandler : IRequestHandler<GetChatMessageByIdRequest, GetChatMessageByIdResponse>
{
    private readonly IChatMessageRepository _chatMessageRepository;

    public GetChatMessageByIdHandler(IChatMessageRepository chatMessageRepository)
    {
        _chatMessageRepository = chatMessageRepository;
    }

    public async Task<GetChatMessageByIdResponse> Handle(GetChatMessageByIdRequest request, CancellationToken cancellationToken)
    {
        var chatMessage = await _chatMessageRepository.GetByIdAsync(request.Id);

        if (chatMessage == null)
            throw new NotFoundException("Chat message not found");

        return new GetChatMessageByIdResponse
        {
            ChatMessage = new ChatMessageResponseDto
            {
                MessageId = chatMessage.MessageId,
                ChatId = chatMessage.ChatId,
                Sender = chatMessage.Sender,
                MessageText = chatMessage.MessageText,
                CreatedAt = chatMessage.CreatedAt
            }
        };
    }
}

public class GetChatMessagesByChatIdHandler : IRequestHandler<GetChatMessagesByChatIdRequest, GetChatMessagesByChatIdResponse>
{
    private readonly IChatMessageRepository _chatMessageRepository;

    public GetChatMessagesByChatIdHandler(IChatMessageRepository chatMessageRepository)
    {
        _chatMessageRepository = chatMessageRepository;
    }

    public async Task<GetChatMessagesByChatIdResponse> Handle(GetChatMessagesByChatIdRequest request, CancellationToken cancellationToken)
    {
        var chatMessages = await _chatMessageRepository.GetByChatIdAsync(request.ChatId);

        var chatMessageDtos = chatMessages.Select(cm => new ChatMessageResponseDto
        {
            MessageId = cm.MessageId,
            ChatId = cm.ChatId,
            Sender = cm.Sender,
            MessageText = cm.MessageText,
            CreatedAt = cm.CreatedAt
        });

        return new GetChatMessagesByChatIdResponse { ChatMessages = chatMessageDtos };
    }
}

public class UpdateChatMessageHandler : IRequestHandler<UpdateChatMessageRequest, UpdateChatMessageResponse>
{
    private readonly IChatMessageRepository _chatMessageRepository;

    public UpdateChatMessageHandler(IChatMessageRepository chatMessageRepository)
    {
        _chatMessageRepository = chatMessageRepository;
    }

    public async Task<UpdateChatMessageResponse> Handle(UpdateChatMessageRequest request, CancellationToken cancellationToken)
    {
        var chatMessage = await _chatMessageRepository.GetByIdAsync(request.Id);

        if (chatMessage == null)
            throw new NotFoundException("Chat message not found");

        chatMessage.MessageText = request.ChatMessageDto.MessageText;

        await _chatMessageRepository.UpdateAsync(chatMessage);

        return new UpdateChatMessageResponse { Message = "Chat message updated successfully" };
    }
}

public class DeleteChatMessageHandler : IRequestHandler<DeleteChatMessageRequest, DeleteChatMessageResponse>
{
    private readonly IChatMessageRepository _chatMessageRepository;

    public DeleteChatMessageHandler(IChatMessageRepository chatMessageRepository)
    {
        _chatMessageRepository = chatMessageRepository;
    }

    public async Task<DeleteChatMessageResponse> Handle(DeleteChatMessageRequest request, CancellationToken cancellationToken)
    {
        var chatMessage = await _chatMessageRepository.GetByIdAsync(request.Id);

        if (chatMessage == null)
            throw new NotFoundException("Chat message not found");

        await _chatMessageRepository.DeleteAsync(request.Id);

        return new DeleteChatMessageResponse { Message = "Chat message deleted successfully" };
    }
}
