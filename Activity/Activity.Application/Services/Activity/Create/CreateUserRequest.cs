﻿using Activity.Application.Dtos;
using FluentValidation;

namespace Activity.Application.Services.User.Create;

public record CreateActivityRequest(
    Guid UserId,
    string Location,
    DateTime StartTime,
    DateTime EndTime,
    double Distance)
    : IRequest<CreateActivityResponse>;

public record CreateActivityResponse(Guid Id);

public class CreateActivityRequestValidator : AbstractValidator<CreateActivityRequest>
{
    public CreateActivityRequestValidator()
    {
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