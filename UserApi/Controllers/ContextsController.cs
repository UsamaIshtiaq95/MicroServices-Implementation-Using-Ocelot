using Application.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserApi.Controllers;

namespace UserApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContextsController : BaseController
{
    private readonly IMediator _mediator;

    public ContextsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllContextsRequest());
        return HandleResult(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetContextByIdRequest { Id = id });
        return HandleResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateContextRequest request)
    {
        var result = await _mediator.Send(request);
        return HandleCreateResult(result, "Context created successfully");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateContextRequest request)
    {
        request.Id = id;
        var result = await _mediator.Send(request);
        return HandleResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteContextRequest { Id = id });
        return HandleDeleteResult("Context deleted successfully");
    }
}
