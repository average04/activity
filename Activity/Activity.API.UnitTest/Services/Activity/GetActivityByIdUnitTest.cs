using Activity.Application.Exceptions;
using Activity.Application.Services.Activity;
using Activity.Domain;

namespace Activity.API.UnitTest.Services.Activity
{
    public class GetActivityByIdUnitTest : TestFixtures
    {
        [Fact]
        public async void GetActivityById_ShouldSuccess()
        {
            // Arrange
            var handler = new GetActivityByIdHandler(_dbContext);
            var request = new GetActivityByIdRequest(new Guid("615e6f49-1f0b-420a-a5e6-8e0be0f7aea0"));

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.UserId.ShouldBe(new Guid("591a3af4-c915-41b8-8582-0c684795aff6"));
            result.Location.ShouldBe("Asgard");
        }

        [Fact]
        public void GetActivityById_NotFoundException()
        {
            // Arrange
            var handler = new GetActivityByIdHandler(_dbContext);
            var request = new GetActivityByIdRequest(new Guid("615e6f49-1f0b-420a-a5e6-8e0be0f7aea1"));

            // Act
            var result = handler.Handle(request, CancellationToken.None);

            // Assert
            result.ShouldThrow<NotFoundException>();
        }
    }
}