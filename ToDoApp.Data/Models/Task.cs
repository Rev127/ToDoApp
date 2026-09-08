
namespace ToDoApp.Data.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public User User { get; set; } = null!;
        public int TaskCategoriesId { get; set; }
        public Categories TaskCategories { get; set; } = null!;
    }
}
