using MemberShipManage.Server.Models;
using MemberShipManage.Service.UserSvc;
using MemberShipManage.Shared.UserDTO;
using Microsoft.AspNetCore.Mvc;

namespace MemberShipManage.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("get")]
        [HttpGet]
        public User GetUser([FromQuery] UserGetRequest request)
        {
            return userService.GetUser(request);
        }
    }
}
