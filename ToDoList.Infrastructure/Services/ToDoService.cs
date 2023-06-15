using AutoMapper;
using ToDoList.Core.Dtos;
using ToDoList.Core.Dtos.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ToDoList.Core.ViewModels;
using ToDoList.Web.Data;
using ToDoList.Data.Models;
using ToDoList.Core.Exceptions;

namespace ToDoList.Infrastructure.Services
{
    public class ToDoService : IToDoService
    {
        public ApplicationDbContext _db;
        public IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICollaboratorService _collaboratorService; 

        public ToDoService(ApplicationDbContext db, IMapper mapper, IHttpContextAccessor httpContextAccessor, ICollaboratorService collaboratorService)
        {
            _db = db; 
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _collaboratorService = collaboratorService;
        }
        public string userLogged()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        } 
       
        public async Task<ResponseDto> getAll(Pagination pagination, Query query)
        {
            var userId = userLogged();  
            var queryString = _db.ToDoLists
                                       .Where(t => t.UserId == userId && !t.IsDelete && (t.Title.Contains(query.GeneralSearch) || string.IsNullOrWhiteSpace(query.GeneralSearch))).AsQueryable();

            var dataCount = queryString.Count();

            var skipValue = pagination.GetSkipValue();

            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();

            var tracks = _mapper.Map<List<ToDoViewModel>>(dataList);

            var pages = pagination.GetPages(dataCount);

            var result = new ResponseDto
            {
                data = tracks,
                meta = new Meta
                {
                    page = pagination.Page,
                    perpage = pagination.PerPage,
                    pages = pages,
                    total = dataCount
                }
            };
            return result;
        }
         
        public async Task<int> Create(CreateToDoListDto todoDto)
        {
            var todo = _mapper.Map<ToDo>(todoDto);
            await _db.ToDoLists.AddAsync(todo);
            await _db.SaveChangesAsync();
            return todo.Id;
        } 
       
        public async Task<UpdateToDoListDto> Get(int Id)
        {
            var todo = await _db.ToDoLists.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (todo == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateToDoListDto>(todo);
        }

        public async Task<int> Update(UpdateToDoListDto todoDto)
        {
            var todo = await _db.ToDoLists.SingleOrDefaultAsync(x => x.Id == todoDto.Id && !x.IsDelete);
            if (todo == null)
            {
                throw new EntityNotFoundException();
            }
            todoDto.UpdateAt = DateTime.Now;
            var todoUpdated = _mapper.Map<UpdateToDoListDto, ToDo>(todoDto, todo);

            _db.ToDoLists.Update(todoUpdated);
            await _db.SaveChangesAsync();
            return todoUpdated.Id;
        }
         
        public async Task<int> Delete(int Id)
        {
            var todo = await _db.ToDoLists.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (todo == null)
            {
                throw new EntityNotFoundException();
            } 
            todo.IsDelete = true;

            _db.ToDoLists.Update(todo);
            await _db.SaveChangesAsync();

            return todo.Id;
        }

        public async Task<List<ToDoViewModel>> GetToDoList()
        {
            var todo = await _db.ToDoLists.Where(x => !x.IsDelete).ToListAsync();
            return _mapper.Map<List<ToDoViewModel>>(todo);  
        }

    }
}
