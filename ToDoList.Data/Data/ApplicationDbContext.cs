using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data.Models;
 
namespace ToDoList.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>  
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        } 
        public DbSet<ToDo> ToDoLists { get; set; } 
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<Collaborator> Collaborators { get; set; } 


    }
}