using System.Net;

namespace ToDoApp.Services.Exceptions.UserExceptions
{
    public class UserNotFoundException : ToDoAppBaseExeption
    {
        public UserNotFoundException(string message) : base(message, HttpStatusCode.NotFound)
        {
        }   
    }
}
