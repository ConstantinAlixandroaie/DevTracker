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
            _logger.LogInformation($"Task item with {taskItem.Id} has been created!");
            return Result<TaskItem>.Success(taskItem);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex.Message);
            return Result<TaskItem>.Failure(ErrorType.Unexpected, ex.Message);
        }
    }

    public async Task<Result<TaskItem>> DeleteTaskItemAsync(long taskItemId)
    {
        var taskItem = _ctx.TaskItems.FirstOrDefault(taskItem => taskItem.Id == taskItemId);

        if (taskItem == null)
        {
            _logger.LogError("The task does not exist.");
            return Result<TaskItem>.Failure(ErrorType.NotFound, "The task does not exist.");
        }

        try
        {
            _ctx.TaskItems.Remove(taskItem);
            await _ctx.SaveChangesAsync();
            _logger.LogInformation($"Task item with {taskItem.Id} has been deleted!");
            return Result<TaskItem>.Success(taskItem);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex.Message);
            return Result<TaskItem>.Failure(ErrorType.Unexpected, ex.Message);
        }
    }

    public async Task<Result<IEnumerable<TaskItem>>> GetTaskItemsAsync(long boardId)
    {
        try
        {
            var taskItems = await _ctx.TaskItems.Where(x => x.BoardId == boardId).AsNoTracking().ToListAsync();
            return Result<IEnumerable<TaskItem>>.Success(taskItems);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex.Message);
            return Result<IEnumerable<TaskItem>>.Failure(ErrorType.Unexpected, ex.Message);
        }
    }

    public async Task<Result<TaskItem>> UpdateTaskItemStatusAsync(long taskItemId, Status status)
    {
        var taskItem = _ctx.TaskItems.FirstOrDefault(item => item.Id == taskItemId);

        if (taskItem is null)
        {
            _logger.LogError("The task does not exist.");
            return Result<TaskItem>.Failure(ErrorType.NotFound, "Task Item not found");
        }

        if (taskItem.Status == status)
        {
            _logger.LogError("Update status did not change status value.");
            return Result<TaskItem>.Failure(ErrorType.Conflict, "Task Item Status not changed.");
        }

        taskItem.Status = status;
        taskItem.UpdatedAt = DateTime.Now;

        try
        {
            await _ctx.SaveChangesAsync();
            _logger.LogInformation($"Task item with {taskItem.Id} has been updated to {status}!");
            return Result<TaskItem>.Success(taskItem);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex.Message);
            return Result<TaskItem>.Failure(ErrorType.Unexpected, ex.Message);
        }
    }
}
