using Activity.Application.Exceptions;
using Activity.Application.Services.Activity;

namespace Activity.API.UnitTest.Services.Activity
{
    public class UpdateActivityUnitTest : TestFixtures
    {
        [Fact]
        public void UpdateActivity_ShouldSuccess()
        {
            // Arrange
            var handler = new UpdateActivityHandler(_dbContext);
            var request = new UpdateActivityRequest(
                new Guid("615e6f49-1f0b-420a-a5e6-8e0be0f7aea0"),
                new Guid("b798c55b-0d79-4327-af75-8ad6e84fbf14"),
                "Updated location",
                DateTime.Now.AddHours(-4),
                DateTime.Now,
                25);

            // Act
            var result = handler.Handle(request, CancellationToken.None);

            // Assert
            result.ShouldNotThrow();
        }

        [Fact]
        public void UpdateActivity_ActivityIdNotFound()
        {
            // Arrange
            var handler = new UpdateActivityHandler(_dbContext);
            var request = new UpdateActivityRequest(
                new Guid("615e6f49-1f0b-420a-a5e6-8e0be0f7aea1"),
                new Guid("b198c55b-0d79-4327-af75-8ad6e84fbf11"),
                "Updated location",
                DateTime.Now.AddHours(-4),
                DateTime.Now,
                25);

            // Act
            var result = handler.Handle(request, CancellationToken.None);

            // Assert
            result.ShouldThrow<NotFoundException>();
        }

        [Fact]
        public void UpdateActivity_UserIdNotFound()
        {
            // Arrange
            var handler = new UpdateActivityHandler(_dbContext);
            var request = new UpdateActivityRequest(
                new Guid("615e6f49-1f0b-420a-a5e6-8e0be0f7aea0"),
                new Guid("b198c55b-0d79-4327-af75-8ad6e84fbf11"),
                "Updated location",
                DateTime.Now.AddHours(-4),
                DateTime.Now,
                25);

            // Act
            var result = handler.Handle(request, CancellationToken.None);

            // Assert
            result.ShouldThrow<NotFoundException>();
        }
    }
}