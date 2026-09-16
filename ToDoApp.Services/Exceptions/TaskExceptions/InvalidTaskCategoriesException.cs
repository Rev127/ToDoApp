using System;
using System.Net;

namespace ToDoApp.Services.Exceptions.TaskExceptions
{
    public class InvalidTaskCategoriesException : ToDoAppBaseExeption
    {
        public InvalidTaskCategoriesException(string message) : base(message, HttpStatusCode.Forbidden)
        {
        }
    }
}
