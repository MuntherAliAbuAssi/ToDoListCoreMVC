using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.Enums;

namespace ToDoList.Data.Models
{
    public class ToDoItem
    {
        public ToDoItem()
        {
            CreateAt = DateTime.Now;
            IsDelete = false;
        }
        public int Id { get; set; }
                
        public string Title { get; set; }

        public string Notes { get; set; }

        public ProgressType Status { get; set; } 

        public PriorityType Priority { get; set; }

        public DateTime DueDate { get; set; }
        
        public int ToDoListId { get; set; }

        public ToDo ToDoList { get; set; }
       
        public DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public bool IsDelete { get; set; }
    }
}
