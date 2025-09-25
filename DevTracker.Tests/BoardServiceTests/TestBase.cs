using DevTracker.Application.Interfaces;
using DevTracker.Application.Services;
using DevTracker.Contracts.Requests.Boards;
using DevTracker.Data.Repositories.Interfaces;
using NSubstitute;

namespace DevTracker.Application.Tests.BoardServiceTests;

public class TestBase : IDisposable
{
    protected IBoardRepository _boardRepo = Substitute.For<IBoardRepository>();
    protected IBoardService _sut;
    protected CreateBoardRequest CreateBoardRequest = new();
    protected UpdateBoardRequest UpdateBoardRequest = new() { BoardId =1,Title="TestBoard Update"};

    public TestBase()
    {
        _sut = Substitute.For<BoardService>(_boardRepo);
    }

    public void Dispose()
    {
    }
}
