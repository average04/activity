namespace Activity.API.Controllers.RequestBody;

public record CreateActivityRequestBody(
    string Location,
    DateTime StartTime,
    DateTime EndTime,
    double Distance);
