using DevTracker.Domain.Enums;
using DevTracker.Domain.IRepositories;
using DevTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DevTracker.Data.Repositories;

public class TaskItemRepository(DevTrackerContext ctx, ILogger<BaseRepository> logger) : BaseRepository(ctx, logger), ITaskItemRepository
{
    public async Task CreateTaskItemAsync(string taskItemTitle)
    {
        var taskItem = new TaskItem
        {
            Title = taskItemTitle
        };

        _ctx.TaskItems.Add(taskItem);

        await _ctx.SaveChangesAsync();
    }

    public async Task DeleteTaskItemAsync(long taskItemId)
    {
        var taskItem = _ctx.TaskItems.FirstOrDefault(taskItem => taskItem.Id == taskItemId);
        if (taskItem == null)
        {
            _logger.LogError("The task does not exist.");
            return;
        }

        _ctx.TaskItems.Remove(taskItem);
        await _ctx.SaveChangesAsync();
    }

    public async Task<List<TaskItem>> GetTaskItemsAsync()
    {
        return await _ctx.TaskItems.ToListAsync();
    }

    public async Task UpdateTaskItemStatusAsync(long taskItemId, Status status)
    {
        var taskItem = _ctx.TaskItems.FirstOrDefault(item => item.Id == taskItemId);
        if (taskItem is null)
        {
            _logger.LogError("The task does not exist.");
            return;
        }

        if(taskItem.Status != status )
        {
            taskItem.Status = status;
            taskItem.UpdatedAt = DateTime.Now;
        }

        _ctx.TaskItems.Update(taskItem);
        await _ctx.SaveChangesAsync();
    }
}
