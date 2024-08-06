

using Activity.Application.Helper;

namespace Activity.Application.Services.User.Create;

public class CreateActionByProcessIdHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly IApplicationDbContext _dbContext;
    public CreateActionByProcessIdHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = request.Adapt<Domain.User>();

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new CreateUserResponse(user.Id);
    }
}
