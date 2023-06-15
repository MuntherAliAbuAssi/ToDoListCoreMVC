using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Core.Dtos
{
    public class UpdateToDoItemDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public DateTime DueDate { get; set; }

        public int ToDoListId { get; set; } 

        public DateTime UpdateAt { get; set; }

    }
}
