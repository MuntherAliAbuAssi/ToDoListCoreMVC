using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.Dtos.Helpers;
using ToDoList.Core.Dtos;

namespace ToDoList.Infrastructure.Services
{
    public interface IToDoItemService
    {
        public Task<int> Create(CreateToDoItemDto todoitemDto);

        public Task<int> Delete(int Id); 

        public Task<UpdateToDoItemDto> Get(int Id);

        public Task<ResponseDto> getAll(Pagination pagination, Query query);

        public Task<int> Update(UpdateToDoItemDto dto);
        public Task<int> UpdateStatus(int Id);

    }
}
