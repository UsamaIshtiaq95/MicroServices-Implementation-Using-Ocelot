using Application.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserApi.Controllers;

namespace UserApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatMessagesController : BaseController
{
    private readonly IMediator _mediator;

    public ChatMessagesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllChatMessagesRequest());
        return HandleResult(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetChatMessageByIdRequest { Id = id });
        return HandleResult(result);
    }

    [HttpGet("chat/{chatId}")]
    public async Task<IActionResult> GetByChatId(int chatId)
    {
        var result = await _mediator.Send(new GetChatMessagesByChatIdRequest { ChatId = chatId });
        return HandleResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateChatMessageRequest request)
    {
        var result = await _mediator.Send(request);
        return HandleCreateResult(result, "Chat message created successfully");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateChatMessageRequest request)
    {
        request.Id = id;
        var result = await _mediator.Send(request);
        return HandleResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteChatMessageRequest { Id = id });
        return HandleDeleteResult("Chat message deleted successfully");
    }
}
