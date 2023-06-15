using ToDoList.Core.Dtos.Helpers;
using ToDoList.Core.Dtos;
using ToDoList.Core.ViewModels;

namespace ToDoList.Infrastructure.Services
{
    public interface IToDoService
    {
        public Task<int> Create(CreateToDoListDto todoDto); 
        
        public Task<int> Delete(int Id);
       
        public Task<UpdateToDoListDto> Get(int Id);
       
        public Task<ResponseDto> getAll(Pagination pagination, Query query);
       
        public Task<int> Update(UpdateToDoListDto dto);
       
        public string userLogged();

        public Task<List<ToDoViewModel>> GetToDoList();

    }
}
