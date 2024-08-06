namespace Activity.API.Controllers.Request;

public record CreateActivityRequestBody(
    string Location,
    DateTime StartTime,
    DateTime EndTime,
    double Distance);
