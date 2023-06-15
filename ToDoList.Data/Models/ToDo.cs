

namespace ToDoList.Data.Models
{
    public class ToDo
    {
        public ToDo()
        { 
            CreateAt = DateTime.Now;
            IsDelete = false;
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public string UserId { get; set; } 

        public User User { get; set; } 

        public DateTime CreateAt { get; set; } 

        public DateTime? UpdateAt { get; set; }

        public bool IsDelete { get; set; }

        public List<ToDoItem> ToDoItems { get; set; }
        public List<Collaborator> Collaborators { get; set; }



    }
}
