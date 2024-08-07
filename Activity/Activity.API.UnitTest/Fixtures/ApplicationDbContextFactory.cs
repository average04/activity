using Activity.Domain;
using System.Runtime.CompilerServices;

namespace Activity.API.UnitTest.Fixtures;

public static class ApplicationDbContextFactory
{
    public static ApplicationDbContext Create()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                   .UseInMemoryDatabase(Guid.NewGuid().ToString())
                   .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                   .EnableSensitiveDataLogging()
                   .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                   .Options;

        var context = new ApplicationDbContext(options);

        context
            .SeedUsers()
            .SeedActivity();

        context.Database.EnsureCreated();

        context.SaveChanges();

        return context;
    }

    public static ApplicationDbContext SeedUsers(this ApplicationDbContext context)
    {
        context.Users.AddRange(new[]
        {
        new User()
        {
            Id = new Guid("591a3af4-c915-41b8-8582-0c684795aff6"),
            Name = "John Doe",
            Weight = 55,
            Height = 143,
            BirthDate = new DateOnly(1998,07,04)
        },
         new User()
        {
            Id = new Guid("b798c55b-0d79-4327-af75-8ad6e84fbf14"),
            Name = "Tony Doe",
            Weight = 45,
            Height = 124,
            BirthDate = new DateOnly(1999,07,04)
        }
        });

        return context;
    }

    public static ApplicationDbContext SeedActivity(this ApplicationDbContext context)
    {
        context.Activities.AddRange(new[]
        {
            new Domain.Activity()
            {
                Id = new Guid("615e6f49-1f0b-420a-a5e6-8e0be0f7aea0"),
                UserId = new Guid("591a3af4-c915-41b8-8582-0c684795aff6"), // John Doe
                Location = "Asgard",
                StartTime = DateTime.Now.AddHours(-2),
                EndTime = DateTime.Now,
                Distance = 20
            },
            new Domain.Activity()
            {
                Id = new Guid("b7f04aa0-40c6-4281-b23d-2c3d2e786e9b"),
                UserId = new Guid("591a3af4-c915-41b8-8582-0c684795aff6"), // John Doe
                Location = "Stark Tower",
                StartTime = DateTime.Now.AddHours(-4),
                EndTime = DateTime.Now.AddHours(-1),
                Distance = 30
            },
            new Domain.Activity()
            {
                Id = new Guid("8f49cb4c-5f83-4742-ad38-c5f973e359ec"),
                UserId = new Guid("b798c55b-0d79-4327-af75-8ad6e84fbf14"), // Tony Doe
                Location = "Stark Tower",
                StartTime = DateTime.Now.AddHours(-5),
                EndTime = DateTime.Now,
                Distance = 40
            }
        });

        return context;
    }
}

