using ToDoApp.Data.Models;
using ToDoApp.Services.Dtos.UserDtos;

namespace ToDoApp.Services.Interfaces
{
    public interface IUserService
    {
        Task<GetUserDtocs> GetUserByIdAsync(string id);
        Task<List<GetUserDtocs>> GetAllUsersAsync();
        Task<GetUserDtocs> GetUserByNameAsync(string name);
    }
}
