using Activity.API.Controllers.Base;

namespace Activity.API.Controllers;

public class ActivityController : BaseController
{

    private readonly ILogger<UserController> _logger;

    public ActivityController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Create activity by user id
    /// </summary>
    /// <param name="id">User id</param>
    /// <param name="body">Create activity request body</param>
    /// <returns></returns>
    [HttpPost("user/{id}/activity")]
    public async Task<IActionResult> CreateActivity([FromRoute] Guid id, [FromBody] CreateActivityRequestBody body)
    {
        var request = new CreateActivityRequest(id, body.Location, body.StartTime, body.EndTime, body.Distance);
        var response = await Mediator.Send(request);

        return Created($"{Request.Path.Value}/{response.Id}", response);
    }

    /// <summary>
    /// Delete activity
    /// </summary>
    /// <param name="id">Activity Id</param>
    /// <returns></returns>
    [HttpDelete("activity/{id}")]
    public async Task<IActionResult> DeleteActivity([FromRoute] Guid id)
    {
        var request = new DeleteActivityRequest(id);
        var response = await Mediator.Send(request);

        return NoContent();
    }

    /// <summary>
    /// Get activity by id
    /// </summary>
    /// <param name="id">Activity id</param>
    /// <returns></returns>
    [HttpGet("activity/{id}")]
    public async Task<IActionResult> GetActivityById([FromRoute] Guid id)
    {
        var request = new GetActivityByIdRequest(id);
        var response = await Mediator.Send(request);

        return Ok(response);
    }

    /// <summary>
    /// Get activities by user id
    /// </summary>
    /// <param name="id">User id</param>
    /// <returns></returns>
    [HttpGet("user/{id}/activity")]
    public async Task<IActionResult> GetActivityByUserId([FromRoute] Guid id)
    {
        var request = new GetActivityByUserIdRequest(id);
        var response = await Mediator.Send(request);

        return response != null ? Ok(response) : NoContent();
    }

    /// <summary>
    /// Update activity
    /// </summary>
    /// <param name="id">Activity id</param>
    /// <param name="body">Update activity request body</param>
    /// <returns></returns>
    [HttpPut("activity/{id}")]
    public async Task<IActionResult> UpdateActivity([FromRoute] Guid id, [FromBody] UpdateActivityRequestBody body)
    {
        var request = new UpdateActivityRequest(id, body.UserId, body.Location, body.StartTime, body.EndTime, body.Distance);
        var response = await Mediator.Send(request);

        return Ok(response);
    }
}

