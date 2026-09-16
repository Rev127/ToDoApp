using Microsoft.AspNetCore.Identity;

namespace ToDoApp.Data.Models
{
    public class User : IdentityUser
    {
        public ICollection<ToDoTask> Tasks { get; set; } = new List<ToDoTask>();
    }
}
