using DevTracker.Domain.DTOs;
using DevTracker.Domain.Enums;
using DevTracker.Domain.IRepositories;
using DevTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DevTracker.Data.Repositories;

public class TaskItemRepository(DevTrackerContext ctx, ILogger<BaseRepository> logger) : BaseRepository(ctx, logger), ITaskItemRepository
{
    public async Task<CreateTaskItemResponse> CreateTaskItemAsync(string taskItemTitle)
    {
        var taskItem = new TaskItem
        {
            Title = taskItemTitle
        };

        try
        {
            _ctx.TaskItems.Add(taskItem);
            await _ctx.SaveChangesAsync();
            return new CreateTaskItemResponse(Result.Success);
        }
        catch (DbUpdateException ex)
        {
            return new CreateTaskItemResponse(Result.Failure, ex.Message);
        }

    }

    public async Task<DeleteTaskItemResponse> DeleteTaskItemAsync(long taskItemId)
    {
        var taskItem = _ctx.TaskItems.FirstOrDefault(taskItem => taskItem.Id == taskItemId);

        if (taskItem == null)
        {
            _logger.LogError("The task does not exist.");
            return new DeleteTaskItemResponse(Result.Failure, "The task does not exist.");
        }

        try
        {
            _ctx.TaskItems.Remove(taskItem);
            await _ctx.SaveChangesAsync();
            return new DeleteTaskItemResponse(Result.Success);
        }
        catch (DbUpdateException ex)
        {
            return new DeleteTaskItemResponse(Result.Failure, ex.Message);
        }
    }

    public async Task<IEnumerable<TaskItem>> GetTaskItemsAsync()
    {
        return await _ctx.TaskItems.ToListAsync();
    }

    public async Task<UpdateTaskItemResponse> UpdateTaskItemStatusAsync(long taskItemId, Status status)
    {
        var taskItem = _ctx.TaskItems.FirstOrDefault(item => item.Id == taskItemId);

        if (taskItem is null)
        {
            _logger.LogError("The task does not exist.");
            return new UpdateTaskItemResponse(Result.Failure, "The task does not exist.");
        }

        if (taskItem.Status == status)
        {
            return new UpdateTaskItemResponse(Result.Failure, "Status not changed, database not updated!");
        }

        taskItem.Status = status;
        taskItem.UpdatedAt = DateTime.Now;

        try
        {
            _ctx.TaskItems.Update(taskItem);
            await _ctx.SaveChangesAsync();
            return new UpdateTaskItemResponse(Result.Success);
        }
        catch (DbUpdateException ex)
        {
            return new UpdateTaskItemResponse(Result.Failure, ex.Message);
        }
    }
}
