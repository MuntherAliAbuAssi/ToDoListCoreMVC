using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ToDoList.Core.Dtos
{
    public class CreateUserDto
    {
        [Required]
        [Display(Name = "اسم المستخدم")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "البريد الإلكتروني")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } 

        [Display(Name = " الصورة ")] 
        public IFormFile Image { get; set; }    

        [Display(Name = " تاريخ الميلاد ")]
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }

    }
}
