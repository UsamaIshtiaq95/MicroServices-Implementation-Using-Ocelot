using Application.DTO;
using Application.Request;
using MediatR;
using UserDomain;
using UserDomain.Entities;
using UserDomain.Interface;

namespace Application.Handler;

public class CreateContextHandler : IRequestHandler<CreateContextRequest, CreateContextResponse>
{
    private readonly IContextRepository _contextRepository;

    public CreateContextHandler(IContextRepository contextRepository)
    {
        _contextRepository = contextRepository;
    }

    public async Task<CreateContextResponse> Handle(CreateContextRequest request, CancellationToken cancellationToken)
    {
        var context = new Contexts
        {
            RoomCount = request.ContextDto.RoomCount,
            ContextData = request.ContextDto.ContextData,
            SourceAI = request.ContextDto.SourceAI,
            CreatedAt = DateTime.Now
        };

        var createdContext = await _contextRepository.AddAsync(context);

        return new CreateContextResponse
        {
            Context = new ContextResponseDto
            {
                ContextId = createdContext.ContextId,
                RoomCount = createdContext.RoomCount,
                ContextData = createdContext.ContextData,
                SourceAI = createdContext.SourceAI,
                CreatedAt = createdContext.CreatedAt
            },
            Message = "Context created successfully"
        };
    }
}

public class GetAllContextsHandler : IRequestHandler<GetAllContextsRequest, GetAllContextsResponse>
{
    private readonly IContextRepository _contextRepository;

    public GetAllContextsHandler(IContextRepository contextRepository)
    {
        _contextRepository = contextRepository;
    }

    public async Task<GetAllContextsResponse> Handle(GetAllContextsRequest request, CancellationToken cancellationToken)
    {
        var contexts = await _contextRepository.GetAllAsync();

        var contextDtos = contexts.Select(c => new ContextResponseDto
        {
            ContextId = c.ContextId,
            RoomCount = c.RoomCount,
            ContextData = c.ContextData,
            SourceAI = c.SourceAI,
            CreatedAt = c.CreatedAt
        });

        return new GetAllContextsResponse { Contexts = contextDtos };
    }
}

public class GetContextByIdHandler : IRequestHandler<GetContextByIdRequest, GetContextByIdResponse>
{
    private readonly IContextRepository _contextRepository;

    public GetContextByIdHandler(IContextRepository contextRepository)
    {
        _contextRepository = contextRepository;
    }

    public async Task<GetContextByIdResponse> Handle(GetContextByIdRequest request, CancellationToken cancellationToken)
    {
        var context = await _contextRepository.GetByIdAsync(request.Id);

        if (context == null)
            throw new NotFoundException("Context not found");

        return new GetContextByIdResponse
        {
            Context = new ContextResponseDto
            {
                ContextId = context.ContextId,
                RoomCount = context.RoomCount,
                ContextData = context.ContextData,
                SourceAI = context.SourceAI,
                CreatedAt = context.CreatedAt
            }
        };
    }
}

public class UpdateContextHandler : IRequestHandler<UpdateContextRequest, UpdateContextResponse>
{
    private readonly IContextRepository _contextRepository;

    public UpdateContextHandler(IContextRepository contextRepository)
    {
        _contextRepository = contextRepository;
    }

    public async Task<UpdateContextResponse> Handle(UpdateContextRequest request, CancellationToken cancellationToken)
    {
        var context = await _contextRepository.GetByIdAsync(request.Id);

        if (context == null)
            throw new NotFoundException("Context not found");

        context.RoomCount = request.ContextDto.RoomCount;
        context.ContextData = request.ContextDto.ContextData;
        context.SourceAI = request.ContextDto.SourceAI;

        await _contextRepository.UpdateAsync(context);

        return new UpdateContextResponse { Message = "Context updated successfully" };
    }
}

public class DeleteContextHandler : IRequestHandler<DeleteContextRequest, DeleteContextResponse>
{
    private readonly IContextRepository _contextRepository;

    public DeleteContextHandler(IContextRepository contextRepository)
    {
        _contextRepository = contextRepository;
    }

    public async Task<DeleteContextResponse> Handle(DeleteContextRequest request, CancellationToken cancellationToken)
    {
        var context = await _contextRepository.GetByIdAsync(request.Id);

        if (context == null)
            throw new NotFoundException("Context not found");

        await _contextRepository.DeleteAsync(request.Id);

        return new DeleteContextResponse { Message = "Context deleted successfully" };
    }
}
