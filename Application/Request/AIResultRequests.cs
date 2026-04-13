using Application.DTO;
using MediatR;

namespace Application.Request;

// AIResult Create
public class CreateAIResultRequest : IRequest<CreateAIResultResponse>
{
    public AIResultCreateDto AIResultDto { get; set; }
}

public class CreateAIResultResponse
{
    public AIResultResponseDto AIResult { get; set; }
    public string Message { get; set; }
}

// AIResult Get All
public class GetAllAIResultsRequest : IRequest<GetAllAIResultsResponse>
{
}

public class GetAllAIResultsResponse
{
    public IEnumerable<AIResultResponseDto> AIResults { get; set; }
}

// AIResult Get By Id
public class GetAIResultByIdRequest : IRequest<GetAIResultByIdResponse>
{
    public int Id { get; set; }
}

public class GetAIResultByIdResponse
{
    public AIResultResponseDto AIResult { get; set; }
}

// AIResult Get By Chat Id
public class GetAIResultsByChatIdRequest : IRequest<GetAIResultsByChatIdResponse>
{
    public int ChatId { get; set; }
}

public class GetAIResultsByChatIdResponse
{
    public IEnumerable<AIResultResponseDto> AIResults { get; set; }
}

// AIResult Update
public class UpdateAIResultRequest : IRequest<UpdateAIResultResponse>
{
    public int Id { get; set; }
    public AIResultUpdateDto AIResultDto { get; set; }
}

public class UpdateAIResultResponse
{
    public string Message { get; set; }
}

// AIResult Delete
public class DeleteAIResultRequest : IRequest<DeleteAIResultResponse>
{
    public int Id { get; set; }
}

public class DeleteAIResultResponse
{
    public string Message { get; set; }
}
