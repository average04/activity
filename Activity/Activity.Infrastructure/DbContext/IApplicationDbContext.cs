namespace Activity.Infrastructure;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<Domain.Activity> Activities { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
