namespace Activity.Application.Services.User.Create;

public class CreateActivityHandler : IRequestHandler<CreateActivityRequest, CreateActivityResponse>
{
    private readonly IApplicationDbContext _dbContext;
    public CreateActivityHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CreateActivityResponse> Handle(CreateActivityRequest request, CancellationToken cancellationToken)
    {
        var activity = request.Adapt<Domain.Activity>();

        var user = await _dbContext.Users.FindAsync(request.UserId);
        if (user == null) throw new NotFoundException("User", request.UserId);

        _dbContext.Activities.Add(activity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new CreateActivityResponse(activity.Id);
    }
}
