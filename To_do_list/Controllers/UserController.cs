using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using To_do_list.Data.Service;

namespace To_do_list.Controllers
{
    [ApiController]
    [Route("Controller")]
    [Authorize]
    public class UserController : Controller
    {
        private LoginService _login;
        public UserController(LoginService login)
        {
            _login = login;
        }
        [HttpGet("get-user")]
        public ActionResult GetUser()
        {
            string username = User.FindFirstValue(ClaimTypes.Name);
            var _response = _login.GetUser(username);
            return Ok(_response);
        }
    }
}
