using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core;
using ToDoList.Core.Dtos;
using ToDoList.Core.Dtos.Helpers;
using ToDoList.Core.Exceptions;
using ToDoList.Core.ViewModels;
using ToDoList.Data.Models;
using ToDoList.Web.Data;

namespace ToDoList.Infrastructure.Services
{
    public class ToDoItemService : IToDoItemService
    {
        public ApplicationDbContext _db;
        public IMapper _mapper;
      
        public ToDoItemService(ApplicationDbContext db, IMapper mapper)
        { 
            _db = db;
            _mapper = mapper;
        }
       
        public async Task<int> Create(CreateToDoItemDto todoitemDto)
        {
            var todoitem = _mapper.Map<ToDoItem>(todoitemDto);
            await _db.ToDoItems.AddAsync(todoitem);
            await _db.SaveChangesAsync();
            return todoitem.Id;
        }

        public async Task<int> Delete(int Id)
        {
            var todoItem = await _db.ToDoItems.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (todoItem == null)
            {
                throw new EntityNotFoundException();
            } 
            todoItem.IsDelete = true;

            _db.ToDoItems.Update(todoItem); 
            await _db.SaveChangesAsync();

            return todoItem.Id;
        }

        public async Task<UpdateToDoItemDto> Get(int Id)
        {
            var todoitem = await _db.ToDoItems.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (todoitem == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateToDoItemDto>(todoitem);
        }

        public async Task<ResponseDto> getAll(Pagination pagination, Query query)
        {
            var queryString = _db.ToDoItems.Include(t => t.ToDoList)
                                       .Where(t => !t.IsDelete && (t.Title.Contains(query.GeneralSearch) || string.IsNullOrWhiteSpace(query.GeneralSearch))).AsQueryable();

            var dataCount = queryString.Count();

            var skipValue = pagination.GetSkipValue();

            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();

            var tracks = _mapper.Map<List<ToDoItemViewModel>>(dataList);   

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

        public async Task<int> Update(UpdateToDoItemDto dto)
        {
            var todo = await _db.ToDoItems.SingleOrDefaultAsync(x => x.Id == dto.Id && !x.IsDelete);
            if (todo == null)
            {
                throw new EntityNotFoundException();
            }
            dto.UpdateAt = DateTime.Now;
            var todoUpdated = _mapper.Map<UpdateToDoItemDto, ToDoItem>(dto, todo);

            _db.ToDoItems.Update(todoUpdated);
            await _db.SaveChangesAsync();
            return todoUpdated.Id;
        }

        public async Task<int> UpdateStatus(int Id)
        {
            var todoItem = await _db.ToDoItems.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (todoItem == null)
            {
                throw new EntityNotFoundException();
            }
            todoItem.Status = Core.Enums.ProgressType.Completed;
            _db.ToDoItems.Update(todoItem);
            await _db.SaveChangesAsync();
            return todoItem.Id;
        }
    }
}
