namespace Activity.Application.Services.User.Create;

public record GetActivityByIdRequest(Guid Id)
    : IRequest<GetActivityByIdResponse>;

public record GetActivityByIdResponse(
    Guid UserId,
    string Location,
    DateTime StartTime,
    DateTime EndTime,
    double Distance,
    TimeSpan Duration,
    double AveragePace);

public class GetActivityByIdRequestValidator : AbstractValidator<GetActivityByIdRequest>
{
    public GetActivityByIdRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}