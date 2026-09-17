using ToDoApp.Services.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ToDoApp.Data.Models;

namespace ToDoApp.Services.Services
{
    public class CurentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor context;
        private readonly string curentUserId;
        private readonly SignInManager<User> userManager;

        public CurentUserService(IHttpContextAccessor context, SignInManager<User> userManager)
        {
            this.context = context;
            this.curentUserId = this.context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            this.userManager = userManager;
        }
        public string GetCurrentUserId()
        {
            return this.curentUserId;
        }

        public bool IsAuthenticated()
        {
            return this.context.HttpContext.User.Identity.IsAuthenticated;
        }

        public string GetCurrentUserName()
        {
            return this.context.HttpContext.User.Identity.Name;
        }

        public async Task Logout()
        {
            await this.userManager.SignOutAsync();
        }
    }
}
