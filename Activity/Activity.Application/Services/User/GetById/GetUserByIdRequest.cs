using Activity.Application.Dtos;
using Activity.Domain.Abstractions;

namespace Activity.Application.Services.User.Create;

public record GetUserByIdRequest(Guid Id)
    : IRequest<GetUserByIdResponse>;

public record GetUserByIdResponse(
    string Name,
    decimal Weight,
    decimal Height,
    DateOnly BirthDate,
    int Age,
    decimal BMI) : UserDto(Name, Weight, Height, BirthDate, Age, BMI);

public class GetUserByIdRequestValidator : AbstractValidator<GetUserByIdRequest>
{
    public GetUserByIdRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}