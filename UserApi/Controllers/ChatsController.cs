using Application.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserApi.Controllers;

namespace UserApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatsController : BaseController
{
    private readonly IMediator _mediator;

    public ChatsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllChatsRequest());
        return HandleResult(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetChatByIdRequest { Id = id });
        return HandleResult(result);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUserId(int userId)
    {
        var result = await _mediator.Send(new GetChatsByUserIdRequest { UserId = userId });
        return HandleResult(result);
    }

    [HttpGet("room/{roomId}")]
    public async Task<IActionResult> GetByRoomId(int roomId)
    {
        var result = await _mediator.Send(new GetChatsByRoomIdRequest { RoomId = roomId });
        return HandleResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateChatRequest request)
    {
        var result = await _mediator.Send(request);
        return HandleCreateResult(result, "Chat created successfully");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateChatRequest request)
    {
        request.Id = id;
        var result = await _mediator.Send(request);
        return HandleResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteChatRequest { Id = id });
        return HandleDeleteResult("Chat deleted successfully");
    }
}
