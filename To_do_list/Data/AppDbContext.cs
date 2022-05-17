using Microsoft.EntityFrameworkCore;

namespace To_do_list.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }
    }
}
