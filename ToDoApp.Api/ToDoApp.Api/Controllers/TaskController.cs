using Microsoft.AspNetCore.Mvc;
using ToDoApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using ToDoApp.Services.Dtos.TaskDtos;

namespace ToDoApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [Authorize]
        [HttpGet("get-all")]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await taskService.GetAllUserTasksAsync();
            return Ok(tasks);
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateTask([FromForm] CreateTaskDto taskDto)
        {
            await taskService.CreateTaskAsync(taskDto);
            return Ok();
        }

        [Authorize]
        [HttpPatch("update/{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromForm] UpdateTaskDto taskDto)
        {
            taskDto.Id = id;
            await taskService.UpdateTaskAsync(taskDto);
            return Ok();
        }

        [Authorize]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await taskService.DeleteTaskAsync(id);
            return Ok();
        }
    }
}
