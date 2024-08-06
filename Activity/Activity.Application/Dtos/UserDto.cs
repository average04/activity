namespace Activity.Application.Dtos;
public record UserDto(
    string Name,
    decimal Weight,
    decimal Height,
    DateOnly BirthDate);
