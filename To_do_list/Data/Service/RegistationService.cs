using To_do_list.Data.Model;
using To_do_list.Data.ViewModel;

namespace To_do_list.Data.Service
{
    public class RegistationService
    {
        private AppDbContext _context;
        public RegistationService( AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public string RegisterUser(Registration registration)
        {
            if(_context.Users.FirstOrDefault(n =>n.UserName == registration.Username)!= null)
            {
                return "Username Already Exist";
            }
            else
            {
                var user = new User()
                {
                    UserName = registration.Username,
                    FirstName = registration.FirstName,
                    LastName = registration.LastName,
                    Password = registration.Password,
                };
                _context.Users.Add(user);
                 user.CreatedAt = DateTime.Now;
                _context.SaveChanges();
                return "Successfully Created";
            }
            
        }
    }
}
