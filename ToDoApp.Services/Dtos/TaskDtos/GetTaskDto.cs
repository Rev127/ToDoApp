namespace ToDoApp.Services.Dtos.TaskDtos
{
    public class GetTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; }
        public bool IsCompleted { get; set; }

    }
}
