using Application.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserApi.Controllers;

namespace UserApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomsController : BaseController
{
    private readonly IMediator _mediator;

    public RoomsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllRoomsRequest());
        return HandleResult(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetRoomByIdRequest { Id = id });
        return HandleResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRoomRequest request)
    {
        var result = await _mediator.Send(request);
        return HandleCreateResult(result, "Room created successfully");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateRoomRequest request)
    {
        request.Id = id;
        var result = await _mediator.Send(request);
        return HandleResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteRoomRequest { Id = id });
        return HandleDeleteResult("Room deleted successfully");
    }
}
