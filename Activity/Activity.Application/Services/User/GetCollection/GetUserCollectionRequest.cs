using Activity.Application.Dtos;
using Activity.Domain.Abstractions;

namespace Activity.Application.Services.User.Create;

public record GetUserCollectionRequest()
    : IRequest<IEnumerable<GetUserCollectionResponse>>;

public record GetUserCollectionResponse(
    string Name,
    decimal Weight,
    decimal Height,
    DateOnly BirthDate,
    int Age,
    decimal BMI);

public class GetUserCollectionRequestValidator : AbstractValidator<GetUserCollectionRequest>
{
}