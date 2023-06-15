using Microsoft.AspNetCore.Mvc;
using ToDoList.Core.Dtos.Helpers;
using ToDoList.Core.Dtos;
using ToDoList.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ToDoList.Web.Controllers
{
    public class ToDoItemController : BaseController 
    {
        private readonly IToDoItemService _todoItemService;
        private readonly IToDoService _todoService;
        private readonly IUserService userService;

        public ToDoItemController(IToDoItemService todoItemService, IUserService _userService, IToDoService todoService) : base(_userService)
        {
            _todoItemService = todoItemService;
            userService = _userService;
            _todoService = todoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetToDoItemData(Pagination pagination, Query query)
        { 
            var result = await _todoItemService.getAll(pagination, query); 

            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create() 
        {
            ViewData["ToDoList"] = new SelectList(await _todoService.GetToDoList(), "Id", "Title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateToDoItemDto todoItemDto)
        {
            if (ModelState.IsValid)
            {
                await _todoItemService.Create(todoItemDto);
                return Ok(Core.Constants.Results.AddSuccessResult());

            }
            ViewData["ToDoList"] = new SelectList(await _todoService.GetToDoList(), "Id", "Title");
            return View(todoItemDto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int Id) 
        {
            ViewData["ToDoList"] = new SelectList(await _todoService.GetToDoList(), "Id", "Title");
            var res = await _todoItemService.Get(Id); 
            return View(res);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateToDoItemDto dto)
        {
            if (ModelState.IsValid)
            {
                await _todoItemService.Update(dto);
                return Ok(Core.Constants.Results.EditSuccessResult());
            }
            ViewData["ToDoList"] = new SelectList(await _todoService.GetToDoList(), "Id", "Title");
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var res = await _todoItemService.Delete(Id);
            return Ok(Core.Constants.Results.DeleteSuccessResult());
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStatus(int Id)
        {
            await _todoItemService.UpdateStatus(Id);
            return Ok(Core.Constants.Results.EditSuccessResult());
        }
    }
}
