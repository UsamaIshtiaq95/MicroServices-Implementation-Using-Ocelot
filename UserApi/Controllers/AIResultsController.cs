using Application.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserApi.Controllers;

namespace UserApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AIResultsController : BaseController
{
    private readonly IMediator _mediator;

    public AIResultsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllAIResultsRequest());
        return HandleResult(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetAIResultByIdRequest { Id = id });
        return HandleResult(result);
    }

    [HttpGet("chat/{chatId}")]
    public async Task<IActionResult> GetByChatId(int chatId)
    {
        var result = await _mediator.Send(new GetAIResultsByChatIdRequest { ChatId = chatId });
        return HandleResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAIResultRequest request)
    {
        var result = await _mediator.Send(request);
        return HandleCreateResult(result, "AI result created successfully");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateAIResultRequest request)
    {
        request.Id = id;
        var result = await _mediator.Send(request);
        return HandleResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteAIResultRequest { Id = id });
        return HandleDeleteResult("AI result deleted successfully");
    }
}
