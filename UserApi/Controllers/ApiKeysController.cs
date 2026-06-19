using Application.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserApi.Controllers;

namespace UserApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApiKeysController : BaseController
{
    private readonly IMediator _mediator;

    public ApiKeysController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllApiKeysRequest());
        return HandleResult(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetApiKeyByIdRequest { Id = id });
        return HandleResult(result);
    }

    [HttpGet("service/{serviceName}")]
    public async Task<IActionResult> GetByServiceName(string serviceName)
    {
        var result = await _mediator.Send(new GetApiKeyByServiceNameRequest { ServiceName = serviceName });
        return HandleResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateApiKeyRequest request)
    {
        var result = await _mediator.Send(request);
        return HandleCreateResult(result, "API key created successfully");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateApiKeyRequest request)
    {
        request.Id = id;
        var result = await _mediator.Send(request);
        return HandleResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteApiKeyRequest { Id = id });
        return HandleDeleteResult("API key deleted successfully");
    }
}
