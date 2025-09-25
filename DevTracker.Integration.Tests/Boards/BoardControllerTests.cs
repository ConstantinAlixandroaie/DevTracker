using DevTracker.API;
using DevTracker.Data.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http.Json;

namespace DevTracker.Integration.Tests.Boards;

public class BoardControllerTests : BaseTest
{
    private CancellationToken CancellationToken = TestContext.Current.CancellationToken;

    public BoardControllerTests(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task GetBoardsAsync_WithoutToken_ExpectUnauthorized()
    {
        //Arrange
        await AuthenticateAsync();

        //Act
        var response = await HttpClient.GetAsync("/api/v1/Board", CancellationToken);

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetBoardsAsync_WithAuthenticatedUserAndNoBoards_ExpectEmptyResponse()
    {
        //Arrange

        //Act
        var response = await HttpClient.GetAsync("/api/v1/Board", CancellationToken);

        //Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task GetBoardByIdAsync_WithoutToken_ExpectUnauthorized()
    {
        //Arrange
        const int boardId = 1;

        //Act
        var response = await HttpClient.GetAsync($"/api/v1/Board/{boardId}", CancellationToken);

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
        var response = await HttpClient.GetAsync($"/api/v1/Board/{boardId}", CancellationToken);

        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetBoardByIdAsync_WithTokenAndExistingBoard_ExpectSuccess()
    {
        //Arrange
        await AuthenticateAsync();
        var boardTitle = "TestBoard Title";
        var createResponse = await HttpClient.PostAsJsonAsync($"/api/v1/Board/CreateBoard", boardTitle, CancellationToken);

        //Act
        var response = await HttpClient.GetAsync($"/api/v1/Board/1", CancellationToken);
        var jsonContent = await response.Content.ReadAsStringAsync();
        var jobject = JObject.Parse(jsonContent);
        var boardjson = jobject["board"].ToString();
        var board = JsonConvert.DeserializeObject<Board>(boardjson);

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(boardTitle, board.Title);
        Assert.Equal(1, board.CreatedBy.Id);
        Assert.Equal(1, board.Owner.Id);

        //cleanup
        var deleteResponse = await HttpClient.DeleteAsync("/api/v1/Board/DeleteBoard?boardId=1", CancellationToken);
    }
}
