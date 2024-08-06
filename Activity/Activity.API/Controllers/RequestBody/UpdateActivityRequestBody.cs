namespace Activity.API.Controllers.Request;

public record UpdateActivityRequestBody(
    Guid UserId,
    string Location,
    DateTime StartTime,
    DateTime EndTime,
    double Distance);
