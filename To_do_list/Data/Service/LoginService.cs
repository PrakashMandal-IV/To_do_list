using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using To_do_list.Data.Model;
using To_do_list.Data.ViewModel;
using To_do_list.HashAlgo;

namespace To_do_list.Data.Service
{
    public class LoginService
    {
        private AppDbContext _context;
        Hash hash = new Hash();
        private readonly IConfiguration _configuration;
        public LoginService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public string Login(LoginVM login)
        {
            string pass = hash.HashPass(login.Password);
            var _user = _context.Users.FirstOrDefault(n => n.UserName == login.UserName);
            if (_user != null && _user.Password == pass)
            {
                return CreateUserToken(_user);
            }
            else
            {
                return "Invalid Details";
            }
        }
        //get user detail
        public User? GetUser(string name)
        {
            var _user = _context.Users.FirstOrDefault(n => n.UserName == name);
            return _user;
        }


        public string CreateUserToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name ,user.UserName),            
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
