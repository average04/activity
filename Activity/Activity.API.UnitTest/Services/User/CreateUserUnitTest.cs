namespace Activity.API.UnitTest.Services.User
{
    public class CreateUserUnitTest : TestFixtures
    {
        [Fact]
        public void CreateUser_ShouldSuccess()
        {
            // Arrange
            var handler = new CreateUserHandler(_dbContext);
            var request = new CreateUserRequest("Bruce Banner", 70, 156, new DateOnly(1992, 04, 03));

            // Act
            var result = handler.Handle(request, CancellationToken.None);

            // Assert
            result.ShouldNotThrow();
        }
    }
}