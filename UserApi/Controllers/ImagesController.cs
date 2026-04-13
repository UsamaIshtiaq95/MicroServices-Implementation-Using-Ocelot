using Application.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserApi.Controllers;

namespace UserApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImagesController : BaseController
{
    private readonly IMediator _mediator;

    public ImagesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllImagesRequest());
        return HandleResult(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetImageByIdRequest { Id = id });
        return HandleResult(result);
    }

    [HttpGet("room/{roomId}")]
    public async Task<IActionResult> GetByRoomId(int roomId)
    {
        var result = await _mediator.Send(new GetImagesByRoomIdRequest { RoomId = roomId });
        return HandleResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateImageRequest request)
    {
        var result = await _mediator.Send(request);
        return HandleCreateResult(result, "Image created successfully");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateImageRequest request)
    {
        request.Id = id;
        var result = await _mediator.Send(request);
        return HandleResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteImageRequest { Id = id });
        return HandleDeleteResult("Image deleted successfully");
    }
}
