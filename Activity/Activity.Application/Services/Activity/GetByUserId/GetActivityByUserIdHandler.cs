namespace Activity.Application.Services.Activity;

public class GetActivityByUserIdHandler : IRequestHandler<GetActivityByUserIdRequest, IEnumerable<GetActivityByUserIdResponse>>
{
    private readonly IApplicationDbContext _dbContext;
    public GetActivityByUserIdHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<GetActivityByUserIdResponse>> Handle(GetActivityByUserIdRequest request, CancellationToken cancellationToken)
    {
        return await _dbContext.Activities.Where(a => a.UserId == request.Id)
            .Select(a => a.Adapt<GetActivityByUserIdResponse>()).ToListAsync();
    }
}
