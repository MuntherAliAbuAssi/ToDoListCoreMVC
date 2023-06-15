using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Core.Constants;
using ToDoList.Core.Dtos;
using ToDoList.Core.Exceptions;
using ToDoList.Infrastructure.Services;

namespace ToDoList.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;


        public UserController(IUserService _userService) : base(_userService)
        {
            this._userService = _userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromForm] CreateUserDto dto)
        {
            if (ModelState.IsValid) 
            {
                try
                {
                    await _userService.Create(dto);
                    return RedirectToAction("Index", "Home");
                }
                catch (DeplicatedEmailOrPhone ex)
                {
                    ModelState.AddModelError("", $"e: {ex.Message}");
                }
                catch (EntityNotFoundException ex)
                {
                    ModelState.AddModelError("", $"e: {ex.Message}");
                }
                catch (OperationFailedException ex)
                {
                    ModelState.AddModelError("", $"e: {ex.Message}");
                }
                catch (InvalidDataException ex)
                {
                    ModelState.AddModelError("", $"e: {ex.Message}");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "e: حدث خطأ ما");
                }

            }
            return View(dto);
        }
    
       
    }
}
