namespace To_do_list.Data.Service
{
    public class RegistationService
    {
        private AppDbContext _context;
        public RegistationService( AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
    }
}
