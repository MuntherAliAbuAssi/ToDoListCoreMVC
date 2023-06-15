using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.Enums;

namespace ToDoList.Core.Dtos
{
    public class CreateToDoItemDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }

        public PriorityType Priority { get; set; }

        public string DueDate { get; set; }

        public int ToDoListId { get; set; }

    }
}
