using Microsoft.AspNetCore.Mvc;
using To_do_list.Data.Service;
using To_do_list.Data.ViewModel;

namespace To_do_list.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class RegistrationController : Controller
    {
        private RegistationService _registration;
        
        public RegistrationController(RegistationService registration)
        {
            _registration = registration;
        }
        [HttpPost("register-user")]
        public ActionResult<string> RegisterUser([FromBody] Registration registrationVM)
        {
            string _result =_registration.RegisterUser(registrationVM);
            if (_result == "Successfully Created")
            {
                return Ok("User Registerd");
            }
            else
            {
                return BadRequest("Username Already exist");
            }
        }      
    }
}
