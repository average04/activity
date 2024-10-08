﻿namespace Activity.Application.Services.User;

public record GetUserByIdRequest(Guid Id)
    : IRequest<GetUserByIdResponse>;

public record GetUserByIdResponse(
    string Name,
    decimal Weight,
    decimal Height,
    DateOnly BirthDate,
    int Age,
    decimal BMI);

public class GetUserByIdRequestValidator : AbstractValidator<GetUserByIdRequest>
{
    public GetUserByIdRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}