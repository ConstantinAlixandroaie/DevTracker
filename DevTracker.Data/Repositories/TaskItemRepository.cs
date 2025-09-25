using DevTracker.Core;
using DevTracker.Data.Enums;
using DevTracker.Data.Models;
using DevTracker.Data.Records;
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

    public async Task<Result<TaskItem>> UpdateTaskItemAsync(UpdateTaskItem updateRequest)
    {
        var taskItem = _ctx.TaskItems.FirstOrDefault(item => item.Id == updateRequest.TaskId);
        var flag = false;
        if (taskItem is null)
        {
            _logger.LogError("The task does not exist.");
            return Result<TaskItem>.Failure(ErrorType.NotFound, "Task Item not found");
        }

        if (updateRequest.Status is not null && taskItem.Status != updateRequest.Status)
        {
            taskItem.Status = (Status)updateRequest.Status;
            flag = true;

        }

        if (updateRequest.Title is not null && updateRequest.Title != taskItem.Title)
        {
            taskItem.Title = updateRequest.Title;
            flag = true;
        }

        if (flag)
        {
            taskItem.UpdatedAt = DateTime.Now;
        }

        try
        {
            await _ctx.SaveChangesAsync();
            _logger.LogInformation($"Task item with {taskItem.Id} has been updated to {updateRequest.Status}!");
            return Result<TaskItem>.Success(taskItem);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex.Message);
            return Result<TaskItem>.Failure(ErrorType.Unexpected, ex.Message);
        }
    }
}
