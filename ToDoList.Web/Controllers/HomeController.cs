using Microsoft.AspNetCore.Mvc;
using ToDoList.Infrastructure.Services;

namespace ToDoList.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

       

        public HomeController(ILogger<HomeController> logger,IUserService _userService) : base(_userService)
        {
            _logger = logger;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}