namespace Activity.Application.Services.Activity;

public class DeleteActivityHandler : IRequestHandler<DeleteActivityRequest, Unit>
{
    private readonly IApplicationDbContext _dbContext;
    public DeleteActivityHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(DeleteActivityRequest request, CancellationToken cancellationToken)
    {
        var activity = await _dbContext.Activities.FindAsync(request.Id);
        if (activity == null) throw new NotFoundException("Activity", request.Id);

        _dbContext.Activities.Remove(activity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
