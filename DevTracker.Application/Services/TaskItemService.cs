using DevTracker.Application.Interfaces;
using DevTracker.Contracts;
using DevTracker.Contracts.Requests.TaskItems;
using DevTracker.Contracts.Responses.TaskItems;
using DevTracker.Core;
using DevTracker.Data.Records;
using DevTracker.Data.Repositories.Interfaces;

namespace DevTracker.Application.Services;

public class TaskItemService : ITaskItemService
{
    private readonly ITaskItemRepository _taskItemRepo;

    public TaskItemService(ITaskItemRepository taskItemRepo)
    {
        _taskItemRepo = taskItemRepo;
    }

    /// <inheritdoc />
    public async Task<CreateTaskItemResponse> CreateTaskItemAsync(CreateTaskItemRequest createTaskItemRequest)
    {
        var result = await _taskItemRepo.CreateTaskItemAsync(createTaskItemRequest.TaskItemTitle);

        if (!result.IsSuccess)
        {
            return new CreateTaskItemResponse(Result.Failure, result.Error);
        }

        return new CreateTaskItemResponse(Result.Success);
    }

    /// <inheritdoc />
    public async Task<DeleteTaskItemResponse> DeleteTaskItemAsync(long taskItemId)
    {
        var result = await _taskItemRepo.DeleteTaskItemAsync(taskItemId);

        if (!result.IsSuccess)
        {
            return new DeleteTaskItemResponse(Result.Failure, result.Error);
        }

        return new DeleteTaskItemResponse(Result.Success);
    }

    /// <inheritdoc />
    public async Task<Response> GetTaskItemsAsync(long boardId)
    {
        var result = await _taskItemRepo.GetTaskItemsAsync(boardId);

        if (!result.IsSuccess)
        {
            return Response.Failure(Result.Failure, result.Error);
        }

        return GetTaskItemsResponse.Success(Result.Success, result.Value);

    }

    /// <inheritdoc />
    public async Task<UpdateTaskItemResponse> UpdateTaskAsync(UpdateTaskItemRequest request)
    {
        UpdateTaskItem updateRequest = new UpdateTaskItem
        (request.TaskId, request.Title, request.Status);

        var result = await _taskItemRepo.UpdateTaskItemAsync(updateRequest);

        if (result.ErrorType == ErrorType.NotFound)
        {
            return new UpdateTaskItemResponse(Result.NotFound, result.Error);
        }

        if (result.ErrorType == ErrorType.Conflict)
        {
            return new UpdateTaskItemResponse(Result.Conflict, result.Error);
        }

        if (result.ErrorType == ErrorType.Unexpected)
        {
            return new UpdateTaskItemResponse(Result.Failure, result.Error);
        }

        return new UpdateTaskItemResponse(Result.Success);
    }
}
