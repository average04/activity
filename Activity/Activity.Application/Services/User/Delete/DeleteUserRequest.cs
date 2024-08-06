﻿using Activity.Application.Dtos;

namespace Activity.Application.Services.User.Create;

public record DeleteUserRequest(Guid Id)
    : IRequest<Unit>;

public class DeleteUserRequestValidator : AbstractValidator<DeleteUserRequest>
{
    public DeleteUserRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}