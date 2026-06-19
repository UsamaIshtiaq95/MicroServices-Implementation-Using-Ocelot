using Application.DTO;
using Application.Request;
using MediatR;
using UserDomain;
using UserDomain.Entities;
using UserDomain.Interface;

namespace Application.Handler;

public class CreateApiKeyHandler : IRequestHandler<CreateApiKeyRequest, CreateApiKeyResponse>
{
    private readonly IApiKeyRepository _apiKeyRepository;

    public CreateApiKeyHandler(IApiKeyRepository apiKeyRepository)
    {
        _apiKeyRepository = apiKeyRepository;
    }

    public async Task<CreateApiKeyResponse> Handle(CreateApiKeyRequest request, CancellationToken cancellationToken)
    {
        var apiKey = new ApiKeys
        {
            ServiceName = request.ApiKeyDto.ServiceName,
            Key = request.ApiKeyDto.Key,
            CreatedAt = DateTime.Now
        };

        var createdApiKey = await _apiKeyRepository.AddAsync(apiKey);

        return new CreateApiKeyResponse
        {
            ApiKey = new ApiKeyResponseDto
            {
                ApiKeyId = createdApiKey.ApiKeyId,
                ServiceName = createdApiKey.ServiceName,
                Key = createdApiKey.Key,
                CreatedAt = createdApiKey.CreatedAt
            },
            Message = "API key created successfully"
        };
    }
}

public class GetAllApiKeysHandler : IRequestHandler<GetAllApiKeysRequest, GetAllApiKeysResponse>
{
    private readonly IApiKeyRepository _apiKeyRepository;

    public GetAllApiKeysHandler(IApiKeyRepository apiKeyRepository)
    {
        _apiKeyRepository = apiKeyRepository;
    }

    public async Task<GetAllApiKeysResponse> Handle(GetAllApiKeysRequest request, CancellationToken cancellationToken)
    {
        var apiKeys = await _apiKeyRepository.GetAllAsync();

        var apiKeyDtos = apiKeys.Select(k => new ApiKeyResponseDto
        {
            ApiKeyId = k.ApiKeyId,
            ServiceName = k.ServiceName,
            Key = k.Key,
            CreatedAt = k.CreatedAt
        });

        return new GetAllApiKeysResponse { ApiKeys = apiKeyDtos };
    }
}

public class GetApiKeyByIdHandler : IRequestHandler<GetApiKeyByIdRequest, GetApiKeyByIdResponse>
{
    private readonly IApiKeyRepository _apiKeyRepository;

    public GetApiKeyByIdHandler(IApiKeyRepository apiKeyRepository)
    {
        _apiKeyRepository = apiKeyRepository;
    }

    public async Task<GetApiKeyByIdResponse> Handle(GetApiKeyByIdRequest request, CancellationToken cancellationToken)
    {
        var apiKey = await _apiKeyRepository.GetByIdAsync(request.Id);

        if (apiKey == null)
            throw new NotFoundException("API key not found");

        return new GetApiKeyByIdResponse
        {
            ApiKey = new ApiKeyResponseDto
            {
                ApiKeyId = apiKey.ApiKeyId,
                ServiceName = apiKey.ServiceName,
                Key = apiKey.Key,
                CreatedAt = apiKey.CreatedAt
            }
        };
    }
}

public class GetApiKeyByServiceNameHandler : IRequestHandler<GetApiKeyByServiceNameRequest, GetApiKeyByServiceNameResponse>
{
    private readonly IApiKeyRepository _apiKeyRepository;

    public GetApiKeyByServiceNameHandler(IApiKeyRepository apiKeyRepository)
    {
        _apiKeyRepository = apiKeyRepository;
    }

    public async Task<GetApiKeyByServiceNameResponse> Handle(GetApiKeyByServiceNameRequest request, CancellationToken cancellationToken)
    {
        var apiKey = await _apiKeyRepository.GetByServiceNameAsync(request.ServiceName);

        if (apiKey == null)
            throw new NotFoundException("API key not found");

        return new GetApiKeyByServiceNameResponse
        {
            ApiKey = new ApiKeyResponseDto
            {
                ApiKeyId = apiKey.ApiKeyId,
                ServiceName = apiKey.ServiceName,
                Key = apiKey.Key,
                CreatedAt = apiKey.CreatedAt
            }
        };
    }
}

public class UpdateApiKeyHandler : IRequestHandler<UpdateApiKeyRequest, UpdateApiKeyResponse>
{
    private readonly IApiKeyRepository _apiKeyRepository;

    public UpdateApiKeyHandler(IApiKeyRepository apiKeyRepository)
    {
        _apiKeyRepository = apiKeyRepository;
    }

    public async Task<UpdateApiKeyResponse> Handle(UpdateApiKeyRequest request, CancellationToken cancellationToken)
    {
        var apiKey = await _apiKeyRepository.GetByIdAsync(request.Id);

        if (apiKey == null)
            throw new NotFoundException("API key not found");

        apiKey.ServiceName = request.ApiKeyDto.ServiceName;
        apiKey.Key = request.ApiKeyDto.Key;

        await _apiKeyRepository.UpdateAsync(apiKey);

        return new UpdateApiKeyResponse { Message = "API key updated successfully" };
    }
}

public class DeleteApiKeyHandler : IRequestHandler<DeleteApiKeyRequest, DeleteApiKeyResponse>
{
    private readonly IApiKeyRepository _apiKeyRepository;

    public DeleteApiKeyHandler(IApiKeyRepository apiKeyRepository)
    {
        _apiKeyRepository = apiKeyRepository;
    }

    public async Task<DeleteApiKeyResponse> Handle(DeleteApiKeyRequest request, CancellationToken cancellationToken)
    {
        var apiKey = await _apiKeyRepository.GetByIdAsync(request.Id);

        if (apiKey == null)
            throw new NotFoundException("API key not found");

        await _apiKeyRepository.DeleteAsync(request.Id);

        return new DeleteApiKeyResponse { Message = "API key deleted successfully" };
    }
}
