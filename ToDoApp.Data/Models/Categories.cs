using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Data.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ToDoTask> Tasks { get; set; } = new List<ToDoTask>();
    }
}
