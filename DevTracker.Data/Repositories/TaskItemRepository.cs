using DevTracker.Core;
using DevTracker.Data.Enums;
using DevTracker.Data.Models;
using DevTracker.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DevTracker.Data.Repositories;

public class TaskItemRepository(DevTrackerContext ctx, ILogger<BaseRepository> logger) : BaseRepository(ctx, logger), ITaskItemRepository
{
    public async Task<Result<TaskItem>> CreateTaskItemAsync(string taskItemTitle)
    {
        var taskItem = new TaskItem
        {
            Title = taskItemTitle
        };

        try
        {
            _ctx.TaskItems.Add(taskItem);
            await _ctx.SaveChangesAsync();
            return Result<TaskItem>.Success(taskItem);
        }
        catch (DbUpdateException ex)
        {
            return Result<TaskItem>.Failure(ex.Message);
        }
    }

    public async Task<Result<TaskItem>> DeleteTaskItemAsync(long taskItemId)
    {
        var taskItem = _ctx.TaskItems.FirstOrDefault(taskItem => taskItem.Id == taskItemId);

        if (taskItem == null)
        {
            return Result<TaskItem>.Failure("The task does not exist.");
        }

        try
        {
            _ctx.TaskItems.Remove(taskItem);
            await _ctx.SaveChangesAsync();
            return Result<TaskItem>.Success(taskItem);
        }
        catch (DbUpdateException ex)
        {
            return Result<TaskItem>.Failure(ex.Message);
        }
    }

    public async Task<Result<IEnumerable<TaskItem>>> GetTaskItemsAsync()
    {
        try
        {
            var taskItems = await _ctx.TaskItems.ToListAsync();
            return Result<IEnumerable<TaskItem>>.Success(taskItems);
        }
        catch (DbUpdateException ex)
        {
            return Result<IEnumerable<TaskItem>>.Failure(ex.Message);
        }
    }

    public async Task<Result<TaskItem>> UpdateTaskItemStatusAsync(long taskItemId, Status status)
    {
        var taskItem = _ctx.TaskItems.FirstOrDefault(item => item.Id == taskItemId);

        if (taskItem is null)
        {
            _logger.LogError("The task does not exist.");
            return Result<TaskItem>.Failure("Task Item not found");
        }

        if (taskItem.Status == status)
        {
            return Result<TaskItem>.Failure("Task Item Status not changed.");
        }

        taskItem.Status = status;
        taskItem.UpdatedAt = DateTime.Now;

        try
        {
            _ctx.TaskItems.Update(taskItem);
            await _ctx.SaveChangesAsync();
            return Result<TaskItem>.Success(taskItem);
        }
        catch (DbUpdateException ex)
        {
            return Result<TaskItem>.Failure(ex.Message);
        }
    }
}
