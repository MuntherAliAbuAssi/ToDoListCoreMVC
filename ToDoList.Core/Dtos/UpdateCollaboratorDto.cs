using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Core.Dtos
{
    public class UpdateCollaboratorDto
    {
        public int Id { get; set; }
        public int ToDoListId { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
