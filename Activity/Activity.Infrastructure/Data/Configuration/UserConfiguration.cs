namespace Activity.Infrastructure.Data.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
           .HasColumnOrder(0);

        builder.Property(c => c.Name)
            .HasMaxLength(255)
            .IsRequired()
            .HasColumnOrder(1); 

        builder.Property(c => c.Weight)
            .IsRequired()
            .HasPrecision(5, 2)
            .HasColumnOrder(2);

        builder.Property(c => c.Height)
            .IsRequired()
            .HasPrecision(5, 2)
            .HasColumnOrder(3);

        builder.Property(c => c.BirthDate)
            .IsRequired()
            .HasColumnOrder(4);

        builder.Property(c => c.Age)
            .HasColumnOrder(5);

        builder.Property(c => c.BMI)
            .HasPrecision(5, 2)
            .HasColumnOrder(6);

    }
}
