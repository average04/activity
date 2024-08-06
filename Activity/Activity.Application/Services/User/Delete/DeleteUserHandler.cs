namespace Activity.Application.Services.User.Create;

public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, Unit>
{
    private readonly IApplicationDbContext _dbContext;
    public DeleteUserHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FindAsync(request.Id);
        if (user == null) throw new NotFoundException("User", request.Id);

        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
