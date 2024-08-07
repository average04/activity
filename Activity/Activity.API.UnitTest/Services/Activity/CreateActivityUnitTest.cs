using Activity.Application.Exceptions;
using Activity.Application.Services.Activity;

namespace Activity.API.UnitTest.Services.Activity
{
    public class CreateActivityUnitTest : TestFixtures
    {
        [Fact]
        public void CreateActivity_ShouldSuccess()
        {
            // Arrange
            var handler = new CreateActivityHandler(_dbContext);
            var request = new CreateActivityRequest(
                new Guid("591a3af4-c915-41b8-8582-0c684795aff6"),
                "Babylon",
                DateTime.Now.AddHours(-4),
                DateTime.Now,
                23);

            // Act
            var result = handler.Handle(request, CancellationToken.None);

            // Assert
            result.ShouldNotThrow();
        }

        [Fact]
        public void CreateActivity_UserIdNotFound()
        {
            // Arrange
            var handler = new CreateActivityHandler(_dbContext);
            var request = new CreateActivityRequest(
                new Guid("591a3af4-c915-41b8-8582-0c684795aff1"),
                "Babylon",
                DateTime.Now.AddHours(-4),
                DateTime.Now,
                23);

            // Act
            var result = handler.Handle(request, CancellationToken.None);

            // Assert
            result.ShouldThrow<NotFoundException>();
        }
    }
}