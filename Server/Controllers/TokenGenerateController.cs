using MemberShipManage.Server.Authetication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberShipManage.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TokenGenerateController : Controller
    {
        private readonly JWTTokenOptions _tokenOptions;
        public TokenGenerateController(JWTTokenOptions tokenOptions)
        {
            _tokenOptions = tokenOptions;
        }

        [HttpPost]
        public TokenResult GenerateJwt()
        {
            var token = new JwtTokenHelper().BuildAuthorizeToken(123456, _tokenOptions);
            return token;
        }
    }
}
