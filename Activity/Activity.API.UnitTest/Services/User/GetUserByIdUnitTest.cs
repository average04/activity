using Activity.Application.Exceptions;

namespace Activity.API.UnitTest.Services.User
{
    public class GetUserByIdUnitTest : TestFixtures
    {
        [Fact]
        public async void GetUserById_ShouldSuccess()
        {
            // Arrange
            var handler = new GetUserByIdHandler(_dbContext);
            var request = new GetUserByIdRequest(new Guid("591a3af4-c915-41b8-8582-0c684795aff6"));

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Name.ShouldBeSameAs("John Doe");
        }

        [Fact]
        public void GetUserById_UserNotFound()
        {
            // Arrange
            var handler = new GetUserByIdHandler(_dbContext);
            var request = new GetUserByIdRequest(new Guid("591a3af4-c915-41b8-8582-0c684795aff1"));

            // Act
            var result = handler.Handle(request, CancellationToken.None);

            // Assert
            result.ShouldThrow<NotFoundException>();
        }
    }
}