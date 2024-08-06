namespace Activity.Application.Services.User.Create;

public record GetActivityByUserIdRequest(Guid Id)
    : IRequest<IEnumerable<GetActivityByUserIdResponse>>;

public record GetActivityByUserIdResponse(
    Guid Id,
    Guid UserId,
    string Location,
    DateTime StartTime,
    DateTime EndTime,
    double Distance,
    TimeSpan Duration,
    double AveragePace);

public class GetActivityByUserIdRequestValidator : AbstractValidator<GetActivityByUserIdRequest>
{
    public GetActivityByUserIdRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}