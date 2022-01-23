using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManager_API.Api.Controllers; 

[Route("api/controller")]
[ApiController]
public class UserController : ControllerBase {
    private readonly IMediator _mediator;

    public UserController(IMediator mediator) {
        _mediator = mediator;
    }
    
    [HttpGet("all", Name="GetAllUsers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    // public async Task<ActionResult<List<>
}