using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.Constants;
using ToDoList.Core.Dtos;
using ToDoList.Core.Exceptions;
using ToDoList.Core.ViewModels;
using ToDoList.Data.Models;
using ToDoList.Web.Data;

namespace ToDoList.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly UserManager<User> _userManger;
        private readonly SignInManager<User> _signInManager;
         

        public UserService(ApplicationDbContext db, IMapper mapper, IFileService fileService, UserManager<User> userManger,SignInManager<User> signInManager)
        { 
            _db = db;
            _mapper = mapper;
            _fileService = fileService;
            _userManger = userManger;
            _signInManager = signInManager;
        }
        public async Task<string> Create(CreateUserDto dtoUser)
        {

            var isExist = _db.Users.Any(x => !x.IsDelete && (x.Email == dtoUser.Email));

            if (isExist)
            {
                throw new DeplicatedEmailOrPhone();
            }
            var user = _mapper.Map<User>(dtoUser);
            user.UserName = dtoUser.Email;
            if (dtoUser.Image != null)
            {
                user.ImageUrl = await _fileService.SaveFile(dtoUser.Image, FolderNames.ImagesFolder);
            }
            try
            {
                var result = await _userManger.CreateAsync(user, dtoUser.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return "RedirectToAction(\"Index\", \"Home\")";
                }
            }
            catch (Exception ex)
            {

            }

            return user.Id;
        }
        public  UserViewModel GetUserByUserName(string userName)
        {
            var user =  _db.Users.SingleOrDefault(x => x.UserName == userName && !x.IsDelete);
            if (user == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UserViewModel>(user);
        }

    }
}
