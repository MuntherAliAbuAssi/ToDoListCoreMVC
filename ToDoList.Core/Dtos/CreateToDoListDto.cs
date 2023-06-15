using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ToDoList.Core.Enums;

namespace ToDoList.Core.Dtos
{
    public class CreateToDoListDto  
    {
        public string UserId { get; set; } 

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "عنوان المهمة")]
        public string Title { get; set; }

    }
} 
