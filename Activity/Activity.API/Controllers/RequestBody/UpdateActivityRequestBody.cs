namespace Activity.API.Controllers.RequestBody;

public record UpdateActivityRequestBody(
    Guid UserId,
    string Location,
    DateTime StartTime,
    DateTime EndTime,
    double Distance);
