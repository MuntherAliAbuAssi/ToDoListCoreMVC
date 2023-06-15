using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.Enums;

namespace ToDoList.Core.ViewModels
{
    public class ToDoViewModel
    {
        public int Id { get; set; }  

        public string Title { get; set; } 

        public string UserId { get; set; }

        public string CreateAt { get; set; } 

    }
}
