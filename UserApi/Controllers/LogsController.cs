using Application.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserApi.Controllers;

namespace UserApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LogsController : BaseController
{
    private readonly IMediator _mediator;

    public LogsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllLogsRequest());
        return HandleResult(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetLogByIdRequest { Id = id });
        return HandleResult(result);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUserId(int userId)
    {
        var result = await _mediator.Send(new GetLogsByUserIdRequest { UserId = userId });
        return HandleResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateLogRequest request)
    {
        var result = await _mediator.Send(request);
        return HandleCreateResult(result, "Log created successfully");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateLogRequest request)
    {
        request.Id = id;
        var result = await _mediator.Send(request);
        return HandleResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteLogRequest { Id = id });
        return HandleDeleteResult("Log deleted successfully");
    }
}
