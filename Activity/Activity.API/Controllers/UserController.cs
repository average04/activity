using Activity.API.Controllers.Base;
using Mapster;

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
    /// <param name="body">Create user request body</param>
    /// <returns></returns>
    [HttpPost("user")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestBody body)
    {
        var request = body.Adapt<CreateUserRequest>();
        var response = await Mediator.Send(request);

        return Created($"{Request.Path.Value}/{response.Id}", response);
    }

    /// <summary>
    /// Delete user
    /// </summary>
    /// <param name="id">User id</param>
    /// <returns></returns>
    [HttpDelete("user/{id}")]
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
    [HttpGet("user/{id}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var result = await Mediator.Send(new GetUserByIdRequest(id));
        return Ok(result);
    }

    /// <summary>
    /// Get all users
    /// </summary>
    /// <returns></returns>
    [HttpGet("user")]
    public async Task<IActionResult> GetUsers()
    {
        var result = await Mediator.Send(new GetUserCollectionRequest());
        return result != null ? Ok(result) : NoContent();
    }

    /// <summary>
    /// Update user
    /// </summary>
    /// <param name="id">User id</param>
    /// <param name="body">Update user request body</param>
    /// <returns></returns>ss
    [HttpPut("user/{id}")]
    public async Task<IActionResult> UpdateUsers([FromRoute]Guid id, [FromBody]UpdateUserRequestBody body)
    {
        var request = new UpdateUserRequest(id, body.Name, body.Weight, body.Height, body.BirthDate);
        var result = await Mediator.Send(request);
        return Ok(result);
    }
}

