﻿using Activity.Application.Dtos;

namespace Activity.Application.Services.User.Create;

public record CreateUserRequest(string Name, decimal Weight, decimal Height, DateTime BirthDate)
    : IRequest<CreateUserResponse>;

public record CreateUserResponse(Guid Id);

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(255)
            .NotEmpty();
        RuleFor(x => x.Weight)
            .GreaterThan(0);
        RuleFor(x => x.Height)
            .GreaterThan(0);
        RuleFor(x => x.BirthDate)
              .NotEmpty();
    }
}