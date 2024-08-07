using Activity.Application.Exceptions;

namespace Activity.API.UnitTest.Services.User
{
    public class UpdateUserUnitTest : TestFixtures
    {
        [Fact]
        public void UpdateUser_ShouldSuccess()
        {
            // Arrange
            var handler = new UpdateUserHandler(_dbContext);
            var request = new UpdateUserRequest(
                new Guid("591a3af4-c915-41b8-8582-0c684795aff6"), 
                "Updated User",
                70, 
                156, 
                new DateOnly(1992, 04, 03));

            // Act
            var result = handler.Handle(request, CancellationToken.None);

            // Assert
            result.ShouldNotThrow();
        }

        [Fact]
        public void UpdateUser_UserNotFound()
        {
            // Arrange
            var handler = new UpdateUserHandler(_dbContext);
            var request = new UpdateUserRequest(
                new Guid("591a3af4-c915-41b8-8582-0c684795aff1"),
                "Updated User",
                70,
                156,
                new DateOnly(1992, 04, 03));

            // Act
            var result = handler.Handle(request, CancellationToken.None);

            // Assert
            result.ShouldThrow<NotFoundException>();
        }
    }
}