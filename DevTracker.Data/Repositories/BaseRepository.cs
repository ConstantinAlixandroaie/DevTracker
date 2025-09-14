using Microsoft.Extensions.Logging;

namespace DevTracker.Data.Repositories;

public class BaseRepository
{
    protected DevTrackerContext _ctx;
    protected readonly ILogger _logger;

    public BaseRepository(DevTrackerContext ctx, ILogger<BaseRepository> logger)
    {
        _ctx = ctx;
        _logger = logger;
    }
}
