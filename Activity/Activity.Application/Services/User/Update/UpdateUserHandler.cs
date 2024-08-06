namespace Activity.Application.Services.User;

public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
{
    private readonly IApplicationDbContext _dbContext;
    public UpdateUserHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FindAsync(request.Id);
        if (user == null) throw new NotFoundException("User", request.Id);

        user.Name = request.Name;
        user.Weight = request.Weight;
        user.Height = request.Height;
        user.BirthDate = request.BirthDate;

        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return user.Adapt<UpdateUserResponse>();
    }
}
