using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Todo.Core;
using Todo.Mvc.Models;

namespace Todo.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITenantService _tenantService;
        private readonly ITodoService _todoService;

        public HomeController(ILogger<HomeController> logger,
            ITenantService tenantService,
            ITodoService todoService)
        {
            _logger = logger;
            _tenantService = tenantService;
            _todoService = todoService;
        }

        public async Task<IActionResult> Index()
        {
            var tenants = await _tenantService.LoadAllTenantsAsync();
            var aTenant = tenants.First();
            
            var todoLists= await _todoService.LoadTodoListsAsync(aTenant.Id);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
