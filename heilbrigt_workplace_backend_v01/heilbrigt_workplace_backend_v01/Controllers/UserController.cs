using heilbrigt_workplace_backend_v01.Dtos.UserSystem;
using heilbrigt_workplace_backend_v01.EntityFramework.Manager;
using heilbrigt_workplace_backend_v01.EntityFramework.Models.User;
using heilbrigt_workplace_backend_v01.Migrations;
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
                if (string.IsNullOrEmpty(userFullDto.email))
                    return StatusCode(406, "Eine E-Mail muss angegeben werden!");//Email is Emtpty
                if (string.IsNullOrEmpty(userFullDto.firstname))
                    return StatusCode(406, "Bitte einen Vornamen angeben!");//Firstname ist Empty
                if (string.IsNullOrEmpty(userFullDto.lastname))
                    return StatusCode(406, "Bitte einen Nachnamen angeben!");//Lastname is Empty
                if (userFullDto.adminlevel == 0)
                    return StatusCode(406, "Bitte ein Berechtigungslevel angeben!");//AdminLevel is 0

                return StatusCode(500, ex.Message);
            }
        }
    }
}
