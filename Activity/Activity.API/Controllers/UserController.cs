using Activity.API.Controllers.Base;
using Activity.Application.Services.User.Create;
using System.ComponentModel;

namespace Activity.API.Controllers;

public class UserController : BaseController
{

    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Create user
    /// </summary>
    /// <param name="request">Create user request</param>
    /// <returns></returns>
    [HttpPost(Name = "user")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        var response = await Mediator.Send(request);
        return Created($"{Request.Path.Value}/{response.Id}", response);
    }

    /// <summary>
    /// Delete user
    /// </summary>
    /// <param name="id">User id</param>
    /// <returns></returns>
    [HttpDelete(Name = "user/{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        await Mediator.Send(new DeleteUserRequest(id));
        return NoContent();
    }

    /// <summary>
    /// Get user by id
    /// </summary>
    /// <param name="id">User id</param>
    /// <returns></returns>
    [HttpGet(Name = "user/{id}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var result = await Mediator.Send(new GetUserByIdRequest(id));
        return Ok(result);
    }
}

