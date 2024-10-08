﻿namespace Activity.Application.Services.User;

public record GetUserCollectionRequest()
    : IRequest<IEnumerable<GetUserCollectionResponse>>;

public record GetUserCollectionResponse(
    Guid Id,
    string Name,
    decimal Weight,
    decimal Height,
    DateOnly BirthDate,
    int Age,
    decimal BMI);

public class GetUserCollectionRequestValidator : AbstractValidator<GetUserCollectionRequest>
{
}