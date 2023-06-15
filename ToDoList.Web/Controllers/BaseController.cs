using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ToDoList.Infrastructure.Services;

namespace ToDoList.Web.Controllers
{
    [Authorize] 
    public class BaseController : Controller
    {
        protected readonly IUserService _userService;
        protected string userId;

        public BaseController(IUserService _userService)  
        {
            this._userService = _userService;
        } 

        public override async void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            if (User.Identity.IsAuthenticated) 
            { 
                var username = User.Identity.Name;
                var user = _userService.GetUserByUserName(username); 
                userId = user.Id; 
                ViewBag.FullName = user.Fullname;
                ViewBag.ImageUser = user.ImageUrl;
            }
        }
    }
}
