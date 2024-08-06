namespace Activity.API.Controllers.RequestBody;

public record CreateUserRequestBody(
    string Name,
    decimal Weight,
    decimal Height,
    DateOnly BirthDate);