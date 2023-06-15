using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Core.Dtos.Helpers
{
   public class PagingDto
    {
        // الداتا اللي راجعه
        public Object Data { get; set; }
        // مجموع الداتا
        public int Total { get; set; }
    }
}
