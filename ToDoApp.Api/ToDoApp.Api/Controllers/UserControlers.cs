using Microsoft.AspNetCore.Mvc;
using ToDoApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ToDoApp.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserControlers : Controller
    {
        private readonly IUserService userService;
        public UserControlers(IUserService userService)
        {
            this.userService = userService;
        }

        [Authorize]
        [HttpGet("get-all")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await userService.GetAllUsersAsync();
            return Ok(users);
        }

        [Authorize]
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await userService.GetUserByIdAsync(id);

            return Ok(user);
        }

        [Authorize]
        [HttpGet("get-by-name/{name}")]
        public async Task<IActionResult> GetUserByName(string name)
        {
            var user = await userService.GetUserByNameAsync(name);
            return Ok(user);
        }
    }
}
