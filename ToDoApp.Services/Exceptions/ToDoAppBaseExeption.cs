using System.Net;

namespace ToDoApp.Services.Exceptions
{
    public class ToDoAppBaseExeption : Exception
    {
        private HttpStatusCode statusCode;
        public ToDoAppBaseExeption(string message, HttpStatusCode statusCode) : base(message)
        {
            this.statusCode = statusCode;
        }

        public HttpStatusCode GetStatusCode()
        {
            return statusCode;
        } 
        public override string ToString() {
            return $"ToDoAppBaseExeption: {Message} (Status: {GetStatusCode()})";
        }
    }
}
