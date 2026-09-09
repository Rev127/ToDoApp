using ToDoApp.Services.Dtos.TaskDtos;

namespace ToDoApp.Services.Interfaces
{
    public interface ITaskService
    {
        Task<List<GetTaskDto>> GetAllUserTasksAsync();
        Task CreateTaskAsync(CreateTaskDto taskDto);
        Task UpdateTaskAsync(UpdateTaskDto taskDto);
        Task DeleteTaskAsync(int taskId);
    }
}
