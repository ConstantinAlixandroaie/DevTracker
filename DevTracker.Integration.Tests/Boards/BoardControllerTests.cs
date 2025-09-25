using DevTracker.API;
using DevTracker.Data.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace DevTracker.Integration.Tests.Boards;

public class BoardControllerTests : BaseTest
{
    private CancellationToken CancellationToken = TestContext.Current.CancellationToken;

    public BoardControllerTests(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task GetBoardsAsync_WithAuthenticatedUserAndNoBoards_ExpectEmptyResponse()
    {
        //Arrange
        await AuthenticateAsync();

        //Act
        var response = await HttpClient.GetAsync("/api/v1/Board", CancellationToken);
        var boards = await ParseObjectFromResponseAsync<List<Board>>(response, "boards");

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Empty(boards);
    }


    [Fact]
    public async Task GetBoardsAsync_WithBoardsSeed_ExpectSuccess()
    {
        //Arrange
        await AuthenticateAsync();
        List<Board> seeds = [
            new Board
        {
            Title = "TestBoard Title 1",
            CreatedById = 1,
            OwnerId = 1
        } ,new Board
        {
            Title = "TestBoard Title 2",
            CreatedById = 1,
            OwnerId = 1
        }];

        foreach (var seed in seeds)
        {
            await SeedEntityAsync(seed);
        }

        //Act
        var response = await HttpClient.GetAsync("/api/v1/Board", CancellationToken);
        var boards = await ParseObjectFromResponseAsync<List<Board>>(response, "boards");

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(seeds.Count, boards.Count);
        Assert.Equal(seeds[0].Title, boards[0].Title);
        Assert.Equal(seeds[1].Title, boards[1].Title);
    }

    [Fact]
    public async Task GetBoardsAsync_WithoutAuthorizationToken_ExpectUnauthorized()
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
        var seed = await SeedEntityAsync(new Board
        {
            Title = "TestBoard Title",
            CreatedById = 1,
            OwnerId = 1
        });

        //Act
        var response = await HttpClient.GetAsync($"/api/v1/Board/1", CancellationToken);
        Board? board = await ParseObjectFromResponseAsync<Board>(response, "board");

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(seed.Title, board.Title);
        Assert.Equal(seed.CreatedById, board.CreatedBy.Id);
        Assert.Equal(seed.OwnerId, board.Owner.Id);
    }

    private static async Task<T> ParseObjectFromResponseAsync<T>(HttpResponseMessage response, string propertyName) where T : class
    {
        var jsonContent = await response.Content.ReadAsStringAsync();
        var jobject = JObject.Parse(jsonContent);
        var objectJson = jobject[propertyName].ToString();
        return JsonConvert.DeserializeObject<T>(objectJson);
    }
}
