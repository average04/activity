namespace Activity.Application.Services.Activity;

public record DeleteActivityRequest(Guid Id)
    : IRequest<Unit>;

public class DeleteActivityRequestValidator : AbstractValidator<DeleteActivityRequest>
{
    public DeleteActivityRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}