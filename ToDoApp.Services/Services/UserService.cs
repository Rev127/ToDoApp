using ToDoApp.Services.Interfaces;
using ToDoApp.Services.Dtos.UserDtos;
using ToDoApp.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Services.Services
{
    public class UserService : IUserService
    {
        private readonly ToDoAppContext context;

        public UserService(ToDoAppContext context)
        {
            this.context = context;
        }

        public async Task<GetUserDtocs> GetUserByIdAsync(string id)
        {
            var user = await context.Users.FindAsync(id);

            return new GetUserDtocs
            {
                Name = user.UserName
            };
        }

        public async Task<List<GetUserDtocs>> GetAllUsersAsync()
        {
            return await context.Users.Select(u => new GetUserDtocs
            {
                Name = u.UserName
            }).ToListAsync();
        }

        public async Task<GetUserDtocs> GetUserByNameAsync(string name)
        {
            var user = context.Users.Select(u => new GetUserDtocs
            {
                Name = u.UserName
            }).FirstOrDefault(u => u.Name == name);

            return user;
        }
    }
}
