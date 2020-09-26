using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Todo.Core;
using Todo.mvc.Models.TodoLists;

namespace Todo.Mvc.Controllers
{
    [Authorize]
    public class TodoListsController : Controller
    {
        private readonly ILogger<TodoListsController> _logger;
        private readonly ITenantService _tenantService;
        private readonly ITodoService _todoService;

        public TodoListsController(ILogger<TodoListsController> logger, 
            ITenantService tenantService,
            ITodoService todoService)
        {
            _logger = logger;
            _tenantService = tenantService;
            _todoService = todoService;
        }
        
        // GET
        public async Task<IActionResult> Index()
        {
            var tenants = await _tenantService.LoadAllTenantsAsync();
            var aTenant = tenants.First();
            
            var todoLists= await _todoService.LoadTodoListsAsync(aTenant.Id);

            return View(new IndexViewModel
            {
                TodoListNames = todoLists.Select(x => x.Title).ToList()
            });
        }
    }
}