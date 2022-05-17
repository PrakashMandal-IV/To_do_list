using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using To_do_list.Data.Service;
using To_do_list.Data.ViewModel;

namespace To_do_list.Controllers
{
    [ApiController]
    [Route("Controller")]
    [Authorize]
    public class ListController : Controller
    {
        private ListService _list;
        public ListController(ListService list)
        {
            _list = list;
        }
        [HttpPost("add-task")]
        public ActionResult AddTask([FromBody] ListVM listVM)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            _list.AddToList(listVM, userName);
            return Ok();
        }
        [HttpPost("update-status/{id}")]
        public ActionResult UpdateTaskStatus(int id)
        {
            _list.UpdateStatus(id);
            return Ok();
        }

    }
}
