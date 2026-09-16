using Microsoft.AspNetCore.Mvc;
using ToDoApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ToDoApp.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserControlers : Controller
    {
        private readonly IUserService userService;
        private readonly ICurrentUserService currentUserService;
        public UserControlers(IUserService userService, ICurrentUserService currentUserService)
        {
            this.userService = userService;
            this.currentUserService = currentUserService;
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

        [HttpGet("me")]
        public async Task<IActionResult> GetCurrentUser()
        {
            return Ok(new
            {
                Name = this.currentUserService.GetCurrentUserName(),
                IsAuthenticated = this.currentUserService.IsAuthenticated()
            });
        }

        [Authorize]
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            this.currentUserService.Logout();
            return Ok();
        }
    }
}
