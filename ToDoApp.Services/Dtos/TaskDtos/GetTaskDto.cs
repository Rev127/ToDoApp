using ToDoApp.Services.Dtos.CategoriesDtos;

namespace ToDoApp.Services.Dtos.TaskDtos
{
    public class GetTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public GetCategoriesDto Category { get; set; }
        public string UserId { get; set; }
        public bool IsCompleted { get; set; }

    }
}
