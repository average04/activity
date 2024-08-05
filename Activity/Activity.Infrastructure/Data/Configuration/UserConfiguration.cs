namespace Activity.Infrastructure.Data.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(c => c.Weight)
            .IsRequired();

        builder.Property(c => c.Height)
            .IsRequired();

        builder.Property(c => c.BirthDate)
            .IsRequired();
    }
}
