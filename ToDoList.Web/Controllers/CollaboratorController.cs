using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoList.Core.Dtos;
using ToDoList.Core.Dtos.Helpers;
using ToDoList.Infrastructure.Services;

namespace ToDoList.Web.Controllers
{
    public class CollaboratorController : BaseController
    {
        private readonly ICollaboratorService _collaboratorService;
        private readonly IToDoService _todoService;
        private readonly IUserService userService;
        public CollaboratorController(IUserService _userService, ICollaboratorService collaboratorService, IToDoService todoService) : base(_userService)
        {
            _collaboratorService = collaboratorService;
            userService = _userService;
            _todoService = todoService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CollaboratorUpdateDelete() 
        {
            return View();
        }
        public async Task<JsonResult> GetCollaboratorData(Pagination pagination, Query query)
        {
            var result = await _collaboratorService.getAll(pagination, query); 

            return Json(result);
        }
       
        public async Task<JsonResult> GetAllDataUpdateDelete(Pagination pagination, Query query)
        {
            var result = await _collaboratorService.AllDataUpdateDelete(pagination, query); 

            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        { 
            ViewData["UserId"] = _collaboratorService.userLogged();
            ViewData["ToDoList"] = new SelectList(await _todoService.GetToDoList(), "Id", "Title");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCollaboratorDto todoDto)
        {
             todoDto.UserId = _todoService.userLogged();
            if (ModelState.IsValid)
            {
                await _collaboratorService.Create(todoDto);
                return Ok(Core.Constants.Results.AddSuccessResult());

            }
            ViewData["ToDoList"] = new SelectList(await _todoService.GetToDoList(), "Id", "Title");
            ViewData["UserId"] = _collaboratorService.userLogged();

            return View(todoDto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            ViewData["ToDoList"] = new SelectList(await _todoService.GetToDoList(), "Id", "Title");
            var res = await _collaboratorService.Get(Id);
            return View(res);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCollaboratorDto dto)
        {
            if (ModelState.IsValid)
            {
                await _collaboratorService.Update(dto);
                return Ok(Core.Constants.Results.EditSuccessResult());
            }
            ViewData["ToDoList"] = new SelectList(await _todoService.GetToDoList(), "Id", "Title");
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var res = await _collaboratorService.Delete(Id);
            return Ok(Core.Constants.Results.DeleteSuccessResult());
        }
        
        [HttpGet]
        public async Task<IActionResult> DeleteUpdate(int Id)
        {
            var res = await _collaboratorService.UpdateDeleteCollaborator(Id);
            return Ok(Core.Constants.Results.EditSuccessResult());
        }
    }
}
