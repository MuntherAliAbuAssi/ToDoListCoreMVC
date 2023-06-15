using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace ToDoList.Data.Models
{
    public  class User : IdentityUser
    {
        public User() { 
            CreateAt = DateTime.Now;
            IsDelete = false;
        }
        [Required]
        public string Fullname { get; set; }

        public DateTime? DOB { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public bool IsDelete { get; set; }

        public List<ToDo> toDoLists { get; set; }
        public List<Collaborator> Collaborators { get; set; }

    }
}
