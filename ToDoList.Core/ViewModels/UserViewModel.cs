using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Core.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Fullname { get; set; } 

        public DateTime? DOB { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreateAt { get; set; }

    }
}
