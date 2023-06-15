using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Core.Dtos
{
    public  class CreateCollaboratorDto
    {
        public string UserId { get; set; }
        public int ToDoListId { get; set; }
    }
}
