using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.Enums;

namespace ToDoList.Core.ViewModels
{
    public class ToDoItemViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public string DueDate { get; set; } 
        public ToDoViewModel ToDoList { get; set; }       

        public DateTime CreateAt { get; set; }
    }
}
