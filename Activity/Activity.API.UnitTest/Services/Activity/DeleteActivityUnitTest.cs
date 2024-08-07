using Activity.Application.Exceptions;
using Activity.Application.Services.Activity;

namespace Activity.API.UnitTest.Services.Activity
{
    public class DeleteActivityUnitTest : TestFixtures
    {
        [Fact]
        public void DeleteActivity_ShouldSuccess()
        {
            // Arrange
            var handler = new DeleteActivityHandler(_dbContext);
            var request = new DeleteActivityRequest(new Guid("8f49cb4c-5f83-4742-ad38-c5f973e359ec"));

            // Act
            var result = handler.Handle(request, CancellationToken.None);

            // Assert
            result.ShouldNotThrow();
        }

        [Fact]
        public void DeleteActivity_ActivityIdNotFound()
        {
            // Arrange
            var handler = new DeleteActivityHandler(_dbContext);
            var request = new DeleteActivityRequest(new Guid("1f49cb4c-5f83-4742-ad38-c5f973e359ec"));

            // Act
            var result = handler.Handle(request, CancellationToken.None);

            // Assert
            result.ShouldThrow<NotFoundException>();
        }
    }
}