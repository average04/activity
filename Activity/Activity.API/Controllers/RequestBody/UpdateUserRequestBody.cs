namespace Activity.API.Controllers.RequestBody;

public record UpdateUserRequestBody(
    Guid Id, 
    string Name, 
    decimal Weight, 
    decimal Height, 
    DateOnly BirthDate);