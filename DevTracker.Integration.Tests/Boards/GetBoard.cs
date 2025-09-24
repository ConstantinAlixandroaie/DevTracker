using DevTracker.API;
using DevTracker.Data.Models;
using System.Net;
using System.Net.Http.Headers;

namespace DevTracker.Integration.Tests.Boards;

public class GetBoard : BaseTest
{
    public GetBoard(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task GetBoardByIdAsync_WithoutToken_ExpectUnauthorized()
    {
        //Arrange
        const int boardId = 1;

        //Act
        var response = await HttpClient.GetAsync($"/api/v1/Board/{boardId}", TestContext.Current.CancellationToken);

        //Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task GetBoardByIdAsync_BoardDoesNotExist_ExpectNotFound()
    {
        //Arrange
        const int boardId = 1;
        await AuthenticateAsync();

        //Act
        var response = await HttpClient.GetAsync($"/api/v1/Board/{boardId}", TestContext.Current.CancellationToken);

        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetBoardByIdAsync_WithTokenAndExistingBoard_ExpectSuccess()
    {
        //Arrange
        await AuthenticateAsync();

        var seedReponse = await SeedEntityAsync(new Board
        {
            Title = "TestBoard Title",
            CreatedById = 1,
            OwnerId = 1,
        });
        //Act
        var response = await HttpClient.GetAsync($"/api/v1/Board/{seedReponse.Id}", TestContext.Current.CancellationToken);

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
