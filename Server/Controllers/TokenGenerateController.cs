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
        private readonly JwtTokenHelper _jwtTokenHelper;
        public TokenGenerateController(JWTTokenOptions tokenOptions, JwtTokenHelper jwtTokenHelper)
        {
            _tokenOptions = tokenOptions;
            _jwtTokenHelper = jwtTokenHelper;
        }

        [HttpPost]
        public TokenResult GenerateJwt()
        {
            var token = _jwtTokenHelper.BuildAuthorizeToken(123456, _tokenOptions);
            return token;
        }
    }
}
