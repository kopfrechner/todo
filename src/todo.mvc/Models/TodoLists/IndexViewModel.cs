using System.Collections.Generic;

namespace todo.mvc.Models.TodoLists
{
    public class IndexViewModel
    {
        public IEnumerable<string> TodoListNames { get; set; }
    }
}