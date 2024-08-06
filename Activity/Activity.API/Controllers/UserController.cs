using Activity.API.Controllers.Base;
using Activity.Application.Services.User.Create;
using Microsoft.AspNetCore.Mvc;

namespace Activity.API.Controllers;


public class UserController : BaseController
{

    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "user")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        var response = await Mediator.Send(request);
        return Created($"{Request.Path.Value}/{response.Id}", response);
    }
}

