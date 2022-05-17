using Microsoft.AspNetCore.Mvc;
using To_do_list.Data.Service;
using To_do_list.Data.ViewModel;

namespace To_do_list.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class LoginController : Controller
    {
        private LoginService _loginService;
        public LoginController(LoginService loginService)
        {
            _loginService = loginService;   
        }      
        [HttpPost("login")]
        public ActionResult<string> UserLogin([FromBody] LoginVM login)
        {
            string _result = _loginService.Login(login);
            if( _result == "Invalid Details")
            {
                return BadRequest("Invalid Detail");
            }
            else
            {
                return _result;
            }
        }
    } 
}
