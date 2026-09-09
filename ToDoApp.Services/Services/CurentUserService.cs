using ToDoApp.Services.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace ToDoApp.Services.Services
{
    public class CurentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor context;
        private readonly string curentUserId;

        public CurentUserService(IHttpContextAccessor context)
        {
            this.context = context;
            this.curentUserId = this.context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public string GetCurrentUserId()
        {
            return this.curentUserId;
        }
    }
}
