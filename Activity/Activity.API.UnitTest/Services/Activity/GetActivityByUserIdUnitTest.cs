using Activity.Application.Exceptions;
using Activity.Application.Services.Activity;
using Activity.Domain;

namespace Activity.API.UnitTest.Services.Activity
{
    public class GetActivityByUserIdUnitTest : TestFixtures
    {
        [Fact]
        public async void GetActivityByUserId_ShouldSuccess()
        {
            // Arrange
            var handler = new GetActivityByUserIdHandler(_dbContext);
            var request = new GetActivityByUserIdRequest(new Guid("591a3af4-c915-41b8-8582-0c684795aff6"));

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Count().ShouldBeGreaterThanOrEqualTo(2);
        }
    }
}