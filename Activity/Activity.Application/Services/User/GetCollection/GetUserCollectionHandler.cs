using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Activity.Application.Services.User.Create;

public class GetUserCollectionHandler : IRequestHandler<GetUserCollectionRequest, IEnumerable<GetUserCollectionResponse>>
{
    private readonly IApplicationDbContext _dbContext;

    public GetUserCollectionHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<GetUserCollectionResponse>> Handle(GetUserCollectionRequest request, CancellationToken cancellationToken)
    {
        return await _dbContext.Users.Select(u => u.Adapt<GetUserCollectionResponse>()).ToListAsync();
    }
}
