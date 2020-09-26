using System.Collections.Generic;

namespace Todo.mvc.Models.TodoLists
{
    public class IndexViewModel
    {
        public IEnumerable<string> TodoListNames { get; set; }
    }
}