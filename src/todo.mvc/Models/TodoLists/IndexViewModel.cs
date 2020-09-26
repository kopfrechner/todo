using System.Collections.Generic;

namespace Todo.Mvc.Models.TodoLists
{
    public class IndexViewModel
    {
        public IEnumerable<string> TodoListNames { get; set; }
    }
}