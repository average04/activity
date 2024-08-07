namespace Activity.API.UnitTest.Fixtures;

public class TestFixtures
{
    protected readonly IApplicationDbContext _dbContext;

    public TestFixtures()
    {
        _dbContext = ApplicationDbContextFactory.Create();
    }
}
