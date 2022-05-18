using Microsoft.EntityFrameworkCore;
using To_do_list.Data.Model;

namespace To_do_list.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<TaskList> TodoList { get; set; } = default!;
    }
}
