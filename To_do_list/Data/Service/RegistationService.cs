using To_do_list.Data.Model;
using To_do_list.Data.ViewModel;
using To_do_list.HashAlgo;

namespace To_do_list.Data.Service
{
    public class RegistationService
    {
        private readonly AppDbContext _context;
        Hash hash = new Hash();
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
                string pass = hash.HashPass(registration.Password);
                var user = new User()
                {
                    UserName = registration.Username,
                    FirstName = registration.FirstName,
                    LastName = registration.LastName,
                    Password = pass,
                };
                _context.Users.Add(user);
                 user.CreatedAt = DateTime.Now;
                _context.SaveChanges();
                return "Successfully Created";
            }         
        }
    }
}
