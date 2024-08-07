namespace Activity.API.UnitTest.Service.User
{
    public class GetUserCollectionUnitTest : TestFixtures
    {
        [Fact]
        public async void GetUserCollection_ShouldSuccess()
        {
            // Arrange
            var handler = new GetUserCollectionHandler(_dbContext);
            var request = new GetUserCollectionRequest();

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Count().ShouldBeGreaterThanOrEqualTo(2);
        }
    }
}