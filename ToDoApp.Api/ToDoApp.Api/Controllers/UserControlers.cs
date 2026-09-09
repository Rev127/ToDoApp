using Microsoft.AspNetCore.Mvc;
using ToDoApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ToDoApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserControlers : Controller
    {
        private readonly IUserService userService;
        public UserControlers(IUserService userService)
        {
            this.userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await userService.GetAllUsersAsync();
            return Ok(users);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await userService.GetUserByIdAsync(id);

            return Ok(user);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetUserByName(string name)
        {
            var user = await userService.GetUserByNameAsync(name);
            return Ok(user);
        }
    }
}
