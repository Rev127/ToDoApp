using System.Net;

namespace ToDoApp.Services.Exceptions.TaskExceptions
{
    public class TaskNotFoundException : ToDoAppBaseExeption
    {
        public TaskNotFoundException(string message) : base(message, HttpStatusCode.NotFound)
        {
        }   
    
    }
}
