using Application.DTO;
using Application.Request;
using MediatR;
using UserDomain;
using UserDomain.Entities;
using UserDomain.Interface;

namespace Application.Handler;

public class CreateAIResultHandler : IRequestHandler<CreateAIResultRequest, CreateAIResultResponse>
{
    private readonly IAIResultRepository _aiResultRepository;

    public CreateAIResultHandler(IAIResultRepository aiResultRepository)
    {
        _aiResultRepository = aiResultRepository;
    }

    public async Task<CreateAIResultResponse> Handle(CreateAIResultRequest request, CancellationToken cancellationToken)
    {
        var aiResult = new AIResults
        {
            ChatId = request.AIResultDto.ChatId,
            AIResponse = request.AIResultDto.AIResponse,
            AIUsed = request.AIResultDto.AIUsed,
            CreatedAt = DateTime.Now
        };

        var createdAIResult = await _aiResultRepository.AddAsync(aiResult);

        return new CreateAIResultResponse
        {
            AIResult = new AIResultResponseDto
            {
                ResultId = createdAIResult.ResultId,
                ChatId = createdAIResult.ChatId,
                AIResponse = createdAIResult.AIResponse,
                AIUsed = createdAIResult.AIUsed,
                CreatedAt = createdAIResult.CreatedAt
            },
            Message = "AI result created successfully"
        };
    }
}

public class GetAllAIResultsHandler : IRequestHandler<GetAllAIResultsRequest, GetAllAIResultsResponse>
{
    private readonly IAIResultRepository _aiResultRepository;

    public GetAllAIResultsHandler(IAIResultRepository aiResultRepository)
    {
        _aiResultRepository = aiResultRepository;
    }

    public async Task<GetAllAIResultsResponse> Handle(GetAllAIResultsRequest request, CancellationToken cancellationToken)
    {
        var aiResults = await _aiResultRepository.GetAllAsync();

        var aiResultDtos = aiResults.Select(r => new AIResultResponseDto
        {
            ResultId = r.ResultId,
            ChatId = r.ChatId,
            AIResponse = r.AIResponse,
            AIUsed = r.AIUsed,
            CreatedAt = r.CreatedAt
        });

        return new GetAllAIResultsResponse { AIResults = aiResultDtos };
    }
}

public class GetAIResultByIdHandler : IRequestHandler<GetAIResultByIdRequest, GetAIResultByIdResponse>
{
    private readonly IAIResultRepository _aiResultRepository;

    public GetAIResultByIdHandler(IAIResultRepository aiResultRepository)
    {
        _aiResultRepository = aiResultRepository;
    }

    public async Task<GetAIResultByIdResponse> Handle(GetAIResultByIdRequest request, CancellationToken cancellationToken)
    {
        var aiResult = await _aiResultRepository.GetByIdAsync(request.Id);

        if (aiResult == null)
            throw new NotFoundException("AI result not found");

        return new GetAIResultByIdResponse
        {
            AIResult = new AIResultResponseDto
            {
                ResultId = aiResult.ResultId,
                ChatId = aiResult.ChatId,
                AIResponse = aiResult.AIResponse,
                AIUsed = aiResult.AIUsed,
                CreatedAt = aiResult.CreatedAt
            }
        };
    }
}

public class GetAIResultsByChatIdHandler : IRequestHandler<GetAIResultsByChatIdRequest, GetAIResultsByChatIdResponse>
{
    private readonly IAIResultRepository _aiResultRepository;

    public GetAIResultsByChatIdHandler(IAIResultRepository aiResultRepository)
    {
        _aiResultRepository = aiResultRepository;
    }

    public async Task<GetAIResultsByChatIdResponse> Handle(GetAIResultsByChatIdRequest request, CancellationToken cancellationToken)
    {
        var aiResults = await _aiResultRepository.GetByChatIdAsync(request.ChatId);

        var aiResultDtos = aiResults.Select(r => new AIResultResponseDto
        {
            ResultId = r.ResultId,
            ChatId = r.ChatId,
            AIResponse = r.AIResponse,
            AIUsed = r.AIUsed,
            CreatedAt = r.CreatedAt
        });

        return new GetAIResultsByChatIdResponse { AIResults = aiResultDtos };
    }
}

public class UpdateAIResultHandler : IRequestHandler<UpdateAIResultRequest, UpdateAIResultResponse>
{
    private readonly IAIResultRepository _aiResultRepository;

    public UpdateAIResultHandler(IAIResultRepository aiResultRepository)
    {
        _aiResultRepository = aiResultRepository;
    }

    public async Task<UpdateAIResultResponse> Handle(UpdateAIResultRequest request, CancellationToken cancellationToken)
    {
        var aiResult = await _aiResultRepository.GetByIdAsync(request.Id);

        if (aiResult == null)
            throw new NotFoundException("AI result not found");

        aiResult.AIResponse = request.AIResultDto.AIResponse;
        aiResult.AIUsed = request.AIResultDto.AIUsed;

        await _aiResultRepository.UpdateAsync(aiResult);

        return new UpdateAIResultResponse { Message = "AI result updated successfully" };
    }
}

public class DeleteAIResultHandler : IRequestHandler<DeleteAIResultRequest, DeleteAIResultResponse>
{
    private readonly IAIResultRepository _aiResultRepository;

    public DeleteAIResultHandler(IAIResultRepository aiResultRepository)
    {
        _aiResultRepository = aiResultRepository;
    }

    public async Task<DeleteAIResultResponse> Handle(DeleteAIResultRequest request, CancellationToken cancellationToken)
    {
        var aiResult = await _aiResultRepository.GetByIdAsync(request.Id);

        if (aiResult == null)
            throw new NotFoundException("AI result not found");

        await _aiResultRepository.DeleteAsync(request.Id);

        return new DeleteAIResultResponse { Message = "AI result deleted successfully" };
    }
}
