

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
        var user = new Domain.User()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Weight = request.Weight,
            Height = request.Height,
            BirthDate = DateOnly.FromDateTime(request.BirthDate)
        };                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new CreateUserResponse(user.Id);
    }
}
