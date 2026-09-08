using System.Net;

namespace ToDoApp.Services.Exceptions.CategoriesExceptions
{
    public class CategoriesNotFoundException : ToDoAppBaseExeption
    {
        public CategoriesNotFoundException(string message) : base(message, HttpStatusCode.NotFound)
        {
        }
   
    }
}
