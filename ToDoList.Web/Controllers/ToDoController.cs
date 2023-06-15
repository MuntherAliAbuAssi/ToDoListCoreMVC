using ToDoList.Core.Dtos;
using ToDoList.Core.Dtos.Helpers;
using Microsoft.AspNetCore.Mvc;

using ToDoList.Infrastructure.Services;
using ToDoList.Core.Constants;

namespace ToDoList.Web.Controllers
{
    public class ToDoController : BaseController
    {
        private readonly IToDoService _todoService;
        private readonly IUserService userService;

        public ToDoController(IToDoService todoService, IUserService _userService) : base(_userService)
        {
            _todoService = todoService;
            userService = _userService;
        }

        public IActionResult Index()
        {
            return View();
        }
       
        public async Task<JsonResult> GetToDoData(Pagination pagination, Query query)
        {
            var result = await _todoService.getAll(pagination, query);

            return Json(result);
        }
      
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["UserId"] = _todoService.userLogged();
            return View();  
        }
       
        [HttpPost] 
        public async Task<IActionResult> Create(CreateToDoListDto todoDto)
        {
            todoDto.UserId = _todoService.userLogged(); 
            if (ModelState.IsValid)
            {  
                await _todoService.Create(todoDto); 
                return Ok(Core.Constants.Results.AddSuccessResult());

            }
            ViewData["UserId"] = _todoService.userLogged();
            return View(todoDto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            var res = await _todoService.Get(Id);
            return View(res);
        }
       
        [HttpPost]
        public async Task<IActionResult> Update(UpdateToDoListDto dto)
        {
            if (ModelState.IsValid)
            {
                await _todoService.Update(dto);
                return Ok(Core.Constants.Results.EditSuccessResult());
            }
            return View(dto);
        }
       
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var res = await _todoService.Delete(Id); 
            return Ok(Core.Constants.Results.DeleteSuccessResult());
        }

    }
}
 