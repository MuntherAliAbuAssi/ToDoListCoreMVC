using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Data.Models
{
    public class Collaborator
    {
        public Collaborator()
        {
            CreateAt = DateTime.Now;
            IsDelete = false;
        }
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ToDoListId { get; set; }
        public DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public bool IsDelete { get; set; }
        public virtual User User { get; set; }
        public virtual ToDo ToDoList { get; set; }
    }
}
