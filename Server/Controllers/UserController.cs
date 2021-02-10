using MemberShipManage.Server.Models;
using MemberShipManage.Service.UserSvc;
using MemberShipManage.Shared.UserDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
