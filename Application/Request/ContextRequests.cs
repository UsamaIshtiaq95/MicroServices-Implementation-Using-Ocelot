using Application.DTO;
using MediatR;

namespace Application.Request;

// Context Create
public class CreateContextRequest : IRequest<CreateContextResponse>
{
    public ContextCreateDto ContextDto { get; set; }
}

public class CreateContextResponse
{
    public ContextResponseDto Context { get; set; }
    public string Message { get; set; }
}

// Context Get All
public class GetAllContextsRequest : IRequest<GetAllContextsResponse>
{
}

public class GetAllContextsResponse
{
    public IEnumerable<ContextResponseDto> Contexts { get; set; }
}

// Context Get By Id
public class GetContextByIdRequest : IRequest<GetContextByIdResponse>
{
    public int Id { get; set; }
}

public class GetContextByIdResponse
{
    public ContextResponseDto Context { get; set; }
}

// Context Update
public class UpdateContextRequest : IRequest<UpdateContextResponse>
{
    public int Id { get; set; }
    public ContextUpdateDto ContextDto { get; set; }
}

public class UpdateContextResponse
{
    public string Message { get; set; }
}

// Context Delete
public class DeleteContextRequest : IRequest<DeleteContextResponse>
{
    public int Id { get; set; }
}

public class DeleteContextResponse
{
    public string Message { get; set; }
}
