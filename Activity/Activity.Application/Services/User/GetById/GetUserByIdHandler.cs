namespace Activity.Application.Services.User.Create;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
{
    private readonly IApplicationDbContext _dbContext;

    public GetUserByIdHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FindAsync(request.Id);
        return user != null ? user.Adapt<GetUserByIdResponse>() : throw new NotFoundException("User", request.Id);
    }
}
