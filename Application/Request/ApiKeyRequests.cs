using Application.DTO;
using MediatR;

namespace Application.Request;

// ApiKey Create
public class CreateApiKeyRequest : IRequest<CreateApiKeyResponse>
{
    public ApiKeyCreateDto ApiKeyDto { get; set; }
}

public class CreateApiKeyResponse
{
    public ApiKeyResponseDto ApiKey { get; set; }
    public string Message { get; set; }
}

// ApiKey Get All
public class GetAllApiKeysRequest : IRequest<GetAllApiKeysResponse>
{
}

public class GetAllApiKeysResponse
{
    public IEnumerable<ApiKeyResponseDto> ApiKeys { get; set; }
}

// ApiKey Get By Id
public class GetApiKeyByIdRequest : IRequest<GetApiKeyByIdResponse>
{
    public int Id { get; set; }
}

public class GetApiKeyByIdResponse
{
    public ApiKeyResponseDto ApiKey { get; set; }
}

// ApiKey Get By Service Name
public class GetApiKeyByServiceNameRequest : IRequest<GetApiKeyByServiceNameResponse>
{
    public string ServiceName { get; set; }
}

public class GetApiKeyByServiceNameResponse
{
    public ApiKeyResponseDto ApiKey { get; set; }
}

// ApiKey Update
public class UpdateApiKeyRequest : IRequest<UpdateApiKeyResponse>
{
    public int Id { get; set; }
    public ApiKeyUpdateDto ApiKeyDto { get; set; }
}

public class UpdateApiKeyResponse
{
    public string Message { get; set; }
}

// ApiKey Delete
public class DeleteApiKeyRequest : IRequest<DeleteApiKeyResponse>
{
    public int Id { get; set; }
}

public class DeleteApiKeyResponse
{
    public string Message { get; set; }
}
