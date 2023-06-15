using AutoMapper;
using ToDoList.Core.Dtos;
using ToDoList.Core.ViewModels;
using ToDoList.Data.Models;

namespace ToDoList.Infrastructure.AutoMapper
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<ToDo, ToDoViewModel>();   
            CreateMap<CreateToDoListDto, ToDo>();
            CreateMap<UpdateToDoListDto, ToDo>().ReverseMap();

            CreateMap<ToDoItem, ToDoItemViewModel>();
            CreateMap<CreateToDoItemDto, ToDoItem>();
            CreateMap<UpdateToDoItemDto, ToDoItem>().ReverseMap();


            CreateMap<User, UserViewModel>().ReverseMap(); 
            CreateMap<CreateUserDto, User>().ForMember(x => x.ImageUrl, x => x.Ignore());
            
            CreateMap<CreateCollaboratorDto, Collaborator>();
            CreateMap<Collaborator, CollaboratorViewModel>(); 
            CreateMap<UpdateCollaboratorDto, Collaborator>().ReverseMap();



        }
    }
}
