using ToDoApp.Services.Dtos.TaskDtos;
using ToDoApp.Services.Interfaces;
using ToDoApp.Data.Models;
using ToDoApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Services.Exceptions.TaskExceptions;

namespace ToDoApp.Services.Services
{
    public class TaskService : ITaskService
    {
        private readonly ToDoAppContext context;
        private readonly ICategoriesService categoriesService;
        private readonly ICurrentUserService currentUserService;

        public TaskService(ToDoAppContext context, ICategoriesService categoriesService, ICurrentUserService currentUserService)
        {
            this.context = context;
            this.categoriesService = categoriesService;
            this.currentUserService = currentUserService;
        }

        public async Task CreateTaskAsync(CreateTaskDto taskDto)
        {
            if (!this.categoriesService.IsCategories(taskDto.CategoryId))
            {
                throw new InvalidTaskCategoriesException($"Category with the ID {taskDto.CategoryId} does not exist!");
            }

            var task = new ToDoTask
            {
                Name = taskDto.Title,
                Description = taskDto.Description,
                TaskCategoriesId = taskDto.CategoryId,
                UserId = this.currentUserService.GetCurrentUserId(),
                IsCompleted = false
            };

            await this.context.Tasks.AddAsync(task);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(int taskId)
        {
            var task = await this.context.Tasks.FindAsync(taskId);
            if (task is null)
            {
                throw new TaskNotFoundException($"Task with the ID {taskId} was not found");
            }
            this.context.Tasks.Remove(task);
            await this.context.SaveChangesAsync();
        }

        public async Task<List<GetTaskDto>> GetAllUserTasksAsync()
        {
            var tasks = await this.context.Tasks.Where(t => t.UserId == this.currentUserService.GetCurrentUserId()).ToListAsync();
            return tasks.Select(t => new GetTaskDto
            {
                Id = t.Id,
                Title = t.Name,
                Description = t.Description,
                CategoryId = t.TaskCategoriesId,
                UserId = t.UserId,
                IsCompleted = t.IsCompleted
            }).ToList();
        }

        public async Task UpdateTaskAsync(UpdateTaskDto taskDto)
        {
           var task = await this.context.Tasks.FindAsync(taskDto.Id);

            if (task is null)
            {
                throw new TaskNotFoundException($"Task with the ID {taskDto.Id} was not found");
            }

            if (taskDto.CategoryId is not null)
            {
                if (!this.categoriesService.IsCategories(taskDto.CategoryId.Value))
                {
                    throw new InvalidTaskCategoriesException($"Category with the ID {taskDto.CategoryId} does not exist!");
                }

                task.TaskCategoriesId = taskDto.CategoryId.Value;
            }

            if (taskDto.Title is not null)
            {
                task.Name = taskDto.Title;
            }

            if (taskDto.Description is not null)
            {
                task.Description = taskDto.Description;
            }

            if (taskDto.IsCompleted is not null)
            {
                task.IsCompleted = taskDto.IsCompleted.Value;
            }

            this.context.Tasks.Update(task);
            await this.context.SaveChangesAsync();
        }
    }
}
