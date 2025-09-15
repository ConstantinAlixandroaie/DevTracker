using DevTracker.Application.Interfaces;
using DevTracker.Contracts;
using DevTracker.Contracts.Requests;
using DevTracker.Contracts.Responses;
using DevTracker.Data.Repositories.Interfaces;

namespace DevTracker.Application.Services;

public class TaskItemService : ITaskItemService
{
    private readonly ITaskItemRepository _taskItemRepo;

    public TaskItemService(ITaskItemRepository taskItemRepo)
    {
        _taskItemRepo = taskItemRepo;
    }

    public async Task<CreateTaskItemResponse> CreateTaskItemAsync(CreateTaskItemRequest createTaskItemRequest)
    {
        var result = await _taskItemRepo.CreateTaskItemAsync(createTaskItemRequest.TaskItemTitle);

        if (!result.IsSuccess)
        {
            return new CreateTaskItemResponse(Result.Failure, result.Error);
        }

        return new CreateTaskItemResponse(Result.Success);
    }

    public async Task<DeleteTaskItemResponse> DeleteTaskItemAsync(long taskItemId)
    {
        var result = await _taskItemRepo.DeleteTaskItemAsync(taskItemId);

        if (!result.IsSuccess)
        {
            return new DeleteTaskItemResponse(Result.Failure, result.Error);
        }

        return new DeleteTaskItemResponse(Result.Success);
    }

    public async Task<GetTaskItemsResponse> GetTaskItemsAsync()
    {
        var result = await _taskItemRepo.GetTaskItemsAsync();

        if (!result.IsSuccess)
        {
            return GetTaskItemsResponse.Failure(Result.Failure, result.Error);
        }

        return GetTaskItemsResponse.Success(Result.Success, result.Value);

    }

    public async Task<UpdateTaskItemResponse> UpdateTaskStatusAsync(UpdateTaskItemRequest request)
    {
        var result = await _taskItemRepo.UpdateTaskItemStatusAsync(request.TaskId, request.Status);
        if (!result.IsSuccess)
        {
            return new UpdateTaskItemResponse(Result.Failure, result.Error);
        }
        return new UpdateTaskItemResponse(Result.Success);
    }
}
