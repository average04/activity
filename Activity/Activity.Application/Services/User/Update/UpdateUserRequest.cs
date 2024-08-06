namespace Activity.Application.Services.User.Create;

public record UpdateUserRequest(Guid Id, string Name, decimal Weight, decimal Height, DateOnly BirthDate)
    : IRequest<UpdateUserResponse>;

public record UpdateUserResponse(
    string Name,
    decimal Weight,
    decimal Height,
    DateOnly BirthDate,
    int Age,
    decimal BMI);

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
        RuleFor(x => x.Name)
            .MaximumLength(255)
            .NotEmpty();
        RuleFor(x => x.Weight)
            .GreaterThan(0);
        RuleFor(x => x.Height)
            .GreaterThan(0);
    }
}