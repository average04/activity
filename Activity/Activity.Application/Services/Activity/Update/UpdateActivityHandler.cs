namespace Activity.Application.Services.Activity;

public class UpdateActivityHandler : IRequestHandler<UpdateActivityRequest, UpdateActivityResponse>
{
    private readonly IApplicationDbContext _dbContext;
    public UpdateActivityHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UpdateActivityResponse> Handle(UpdateActivityRequest request, CancellationToken cancellationToken)
    {
        var activity = await _dbContext.Activities.FindAsync(request.Id);
        if (activity == null) throw new NotFoundException("Activity", request.Id);

        _dbContext.Activities.Update(activity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return activity.Adapt<UpdateActivityResponse>();
    }
}
