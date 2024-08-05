namespace Activity.Infrastructure.Data.Configuration;

public class ActivityConfiguration : IEntityTypeConfiguration<Domain.Activity>
{
    public void Configure(EntityTypeBuilder<Domain.Activity> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Location)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(c => c.StartTime)
            .IsRequired();

        builder.Property(c => c.EndTime)
            .IsRequired();

        builder.Property(c => c.Distance)
            .IsRequired();
    }
}
