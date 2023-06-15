using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Core.ViewModels
{
    public class CollaboratorViewModel
    {
        public int Id { get; set; }
        public UserViewModel User { get; set; }
        public ToDoViewModel ToDoList { get; set; }
        public string CreateAt { get; set; }

    }
}
