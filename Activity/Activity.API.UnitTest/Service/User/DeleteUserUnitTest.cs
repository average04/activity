using Activity.Application.Exceptions;

namespace Activity.API.UnitTest.Service.User
{
    public class DeleteUserUnitTest : TestFixtures
    {
        [Fact]
        public void DeleteUser_ShouldSuccess()
        {
            // Arrange
            var handler = new DeleteUserHandler(_dbContext);
            var request = new DeleteUserRequest(new Guid("591a3af4-c915-41b8-8582-0c684795aff6"));

            // Act
            var result = handler.Handle(request, CancellationToken.None);

            // Assert
            result.ShouldNotThrow();
        }

        [Fact]
        public void DeleteUser_UserNotFount()
        {
            // Arrange
            var handler = new DeleteUserHandler(_dbContext);
            var request = new DeleteUserRequest(new Guid("591a3af4-c915-41b8-8582-0c684795aff1"));

            // Act
            var result = handler.Handle(request, CancellationToken.None);

            // Assert
            result.ShouldThrow<NotFoundException>();
        }
    }
}