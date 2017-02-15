using Microsoft.EntityFrameworkCore;

namespace TaskAPI.Entities
{
    public sealed class TaskManagementContext : DbContext
    {

        public TaskManagementContext(DbContextOptions<TaskManagementContext> options) 
            :base(options)
        {
            Database.Migrate();
        }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Assignment> Assignments { get; set; }
    }
}
  