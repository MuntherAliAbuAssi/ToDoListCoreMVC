using ToDoList.Core.Dtos;
using ToDoList.Core.Dtos.Helpers;

namespace ToDoList.Infrastructure.Services
{
    public interface ICollaboratorService
    {
        public Task<int> Create(CreateCollaboratorDto todoitemDto);
       
        public Task<ResponseDto> getAll(Pagination pagination, Query query);
      
        public string userLogged();
        public Task<ResponseDto> AllDataUpdateDelete(Pagination pagination, Query query);
        public Task<int> Delete(int Id); 
       
        public Task<UpdateCollaboratorDto> Get(int Id);
      
        public Task<int> Update(UpdateCollaboratorDto dto);
        public Task<int> UpdateDeleteCollaborator(int Id);


    }
}
