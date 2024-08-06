namespace Activity.Infrastructure.Data.Configuration;

public class ActivityConfiguration : IEntityTypeConfiguration<Domain.Activity>
{
    public void Configure(EntityTypeBuilder<Domain.Activity> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
           .HasColumnOrder(0);

        builder.HasOne<User>()
          .WithMany()
          .HasForeignKey(o => o.UserId)
          .IsRequired();

        builder.Property(c => c.UserId)
          .HasColumnOrder(1);

        builder.Property(c => c.Location)
            .HasMaxLength(255)
            .IsRequired()
            .HasColumnOrder(2);

        builder.Property(c => c.StartTime)
            .IsRequired()
            .HasColumnOrder(3);

        builder.Property(c => c.EndTime)
            .IsRequired()
            .HasColumnOrder(4);

        builder.Property(c => c.Distance)
            .IsRequired()
            .HasColumnOrder(5);

        builder.Property(c => c.Duration)
            .HasColumnOrder(6);

        builder.Property(c => c.AveragePace)
           .HasColumnOrder(7);
    }
}
