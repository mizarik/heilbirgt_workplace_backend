using heilbrigt_workplace_backend_v01.Dtos.UserSystem;
using heilbrigt_workplace_backend_v01.EntityFramework.Manager;
using Microsoft.AspNetCore.Mvc;

namespace heilbrigt_workplace_backend_v01.Controllers
{
    [ApiController]
    [Route("usersystem")]
    public class UserController(IUserManager IUserManager) : ControllerBase
    {
        public readonly IUserManager _IUserManager = IUserManager;

        [HttpPost("adduser", Name = "Adduser")]
        public IActionResult AddNewUser([FromBody] UserFullDto userFullDto)
        {
            try
            {
                return Ok(_IUserManager.AddNewUser(userFullDto));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
