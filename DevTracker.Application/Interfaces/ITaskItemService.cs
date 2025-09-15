using DevTracker.Contracts.Requests;
using DevTracker.Contracts.Responses.TaskItems;
using DevTracker.Contracts.Responses.TaskItems;

namespace DevTracker.Application.Interfaces;

public interface ITaskItemService
{
    Task<CreateTaskItemResponse> CreateTaskItemAsync(CreateTaskItemRequest createTaskItemRequest);
    Task<GetTaskItemsResponse> GetTaskItemsAsync();
    Task<DeleteTaskItemResponse> DeleteTaskItemAsync(long taskItemId);
    Task<UpdateTaskItemResponse> UpdateTaskStatusAsync(UpdateTaskItemRequest request);
}
