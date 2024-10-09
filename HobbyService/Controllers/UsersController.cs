using Microsoft.AspNetCore.Mvc;

namespace HobbyService.Controllers
{
    //the h is because of both the hobbyservice and the userservice have an usercontroller
    [Route("api/h/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersController()
        {
            
        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST # HobbyService");
            return Ok("Inbound test from User Controller");
        }
    }

}