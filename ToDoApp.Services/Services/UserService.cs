using ToDoApp.Services.Interfaces;
using ToDoApp.Services.Dtos.UserDtos;
using ToDoApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Services.Exceptions.UserExceptions;

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
            var user = await this.context.Users.FindAsync(id);

            if(user is null) {
                throw new UserNotFoundException($"User with the ID {id} was not found");
            }

            return new GetUserDtocs
            {
                Name = user.UserName
            };
        }

        public async Task<List<GetUserDtocs>> GetAllUsersAsync()
        {
            return await this.context.Users.Select(u => new GetUserDtocs
            {
                Name = u.UserName
            }).ToListAsync();
        }

        public async Task<GetUserDtocs> GetUserByNameAsync(string name)
        {
            var user = this.context.Users.Select(u => new GetUserDtocs
            {
                Name = u.UserName
            }).FirstOrDefault(u => u.Name == name);

            if (user is null)
            {
                throw new UserNotFoundException($"User with the name {name} was not found");
            }

            return user;
        }
    }
}
