namespace Activity.Application.Services.Activity;

public record UpdateActivityRequest(
    Guid Id,
    Guid UserId,
    string Location,
    DateTime StartTime,
    DateTime EndTime,
    double Distance)
    : IRequest<UpdateActivityResponse>;

public record UpdateActivityResponse(
    Guid Id,
    Guid UserId,
    string Location,
    DateTime StartTime,
    DateTime EndTime,
    double Distance,
    TimeSpan Duration,
    double AveragePace);

public class UpdateActivityRequestValidator : AbstractValidator<UpdateActivityRequest>
{
    public UpdateActivityRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
        RuleFor(x => x.UserId)
            .NotEmpty();
        RuleFor(x => x.Location)
            .MaximumLength(255)
            .NotEmpty();
        RuleFor(x => x.StartTime)
            .NotEmpty();
        RuleFor(x => x.EndTime)
            .NotEmpty();
    }
}