using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.Dtos;
using ToDoList.Core.Exceptions;
using ToDoList.Core.ViewModels;

namespace ToDoList.Infrastructure.Services
{
    public interface IUserService
    { 
        public Task<string> Create(CreateUserDto dtoUser);
        public UserViewModel GetUserByUserName(string userName); 


    }
}
