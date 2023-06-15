using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.Dtos;
using ToDoList.Core.Dtos.Helpers;
using ToDoList.Core.Exceptions;
using ToDoList.Core.ViewModels;
using ToDoList.Data.Models;
using ToDoList.Web.Data;

namespace ToDoList.Infrastructure.Services
{
    public class CollaboratorService : ICollaboratorService
    {
        public ApplicationDbContext _db;
        public IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CollaboratorService(ApplicationDbContext db, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _db = db; 
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public string userLogged()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }
       
        public async Task<int> Create(CreateCollaboratorDto todo)
        {
           var isAdd = await _db.Collaborators.AnyAsync(x => x.ToDoListId == todo.ToDoListId);
            if (isAdd)
            {
                throw new IsFoundException();
            }
            var collobartor = _mapper.Map<Collaborator>(todo);
            await _db.Collaborators.AddAsync(collobartor);
            await _db.SaveChangesAsync();
            return collobartor.Id; 
        }

        public async Task<ResponseDto> getAll(Pagination pagination, Query query)
        {
            var userId = userLogged();

            var queryString = _db.Collaborators.Include(x=>x.User).Include(x=>x.ToDoList)
                                       .Where(t => t.UserId == userId && !t.IsDelete && (t.ToDoList.Title.Contains(query.GeneralSearch) || string.IsNullOrWhiteSpace(query.GeneralSearch))).AsQueryable();

            var dataCount = queryString.Count();

            var skipValue = pagination.GetSkipValue();

            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();

            var tracks = _mapper.Map<List<CollaboratorViewModel>>(dataList);

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
        
        public async Task<ResponseDto> AllDataUpdateDelete(Pagination pagination, Query query)
        {
            var userId = userLogged();

            var queryString = _db.Collaborators.Include(x => x.User).Include(x => x.ToDoList)
                                       .Where(t => t.UserId == userId && (t.ToDoList.Title.Contains(query.GeneralSearch) || string.IsNullOrWhiteSpace(query.GeneralSearch))).AsQueryable();

            var dataCount = queryString.Count();

            var skipValue = pagination.GetSkipValue();

            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();

            var tracks = _mapper.Map<List<CollaboratorViewModel>>(dataList);

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
        public async Task<int> Delete(int Id)
        {
            var coll = await _db.Collaborators.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (coll == null)
            {
                throw new EntityNotFoundException();
            }
            coll.IsDelete = true;

            _db.Collaborators.Update(coll);
            await _db.SaveChangesAsync();

            return coll.Id;
        }
        public async Task<UpdateCollaboratorDto> Get(int Id)
        {

            var coll = await _db.Collaborators.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (coll == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateCollaboratorDto>(coll);
        }

        public async Task<int> Update(UpdateCollaboratorDto dto)
        {
            var coll = await _db.Collaborators.SingleOrDefaultAsync(x => x.Id == dto.Id && !x.IsDelete);
            if (coll == null)
            {
                throw new EntityNotFoundException();
            }
            dto.UpdateAt = DateTime.Now;
            var collUpdated = _mapper.Map<UpdateCollaboratorDto, Collaborator>(dto, coll);

            _db.Collaborators.Update(collUpdated);
            await _db.SaveChangesAsync();
            return collUpdated.Id;
        }
      
        public async Task<int> UpdateDeleteCollaborator(int Id)
        {
            var coll = await _db.Collaborators.SingleOrDefaultAsync(x => x.Id == Id && x.IsDelete); 
            if (coll == null)
            {
                throw new EntityNotFoundException();
            }
            coll.IsDelete = false;

            _db.Collaborators.Update(coll);
            await _db.SaveChangesAsync();

            return coll.Id;
        }

    }
}
