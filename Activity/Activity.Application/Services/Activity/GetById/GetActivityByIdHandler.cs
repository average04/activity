using System.Reflection.Metadata.Ecma335;

namespace Activity.Application.Services.User.Create;

public class GetActivityByIdHandler : IRequestHandler<GetActivityByIdRequest, GetActivityByIdResponse>
{
    private readonly IApplicationDbContext _dbContext;
    public GetActivityByIdHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetActivityByIdResponse> Handle(GetActivityByIdRequest request, CancellationToken cancellationToken)
    {
        var activity = await _dbContext.Activities.FindAsync(request.Id);

        return activity != null ? activity.Adapt<GetActivityByIdResponse>()
            : throw new NotFoundException("Activity", request.Id);
    }
}
