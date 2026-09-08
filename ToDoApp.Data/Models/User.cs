using Microsoft.AspNetCore.Identity;

namespace ToDoApp.Data.Models
{
    public class User : IdentityUser
    {
        public ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}
