using System.Collections.Generic;

namespace Todo.Mvc.Models.Home
{
    public class IndexViewModel
    {
        public string TenantName { get; set; }
        public IEnumerable<string> TodoListNames { get; set; }
    }
}