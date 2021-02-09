using MemberShipManage.Infrastructurer;
using MemberShipManage.Server.Authetication;
using Microsoft.AspNetCore.Mvc;

namespace MemberShipManage.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TokenGenerateController : Controller
    {
        private readonly JWTTokenOptions tokenOptions;
        private readonly JwtTokenHelper jwtTokenHelper;
        public TokenGenerateController(JWTTokenOptions tokenOptions, JwtTokenHelper jwtTokenHelper)
        {
            this.tokenOptions = tokenOptions;
            this.jwtTokenHelper = jwtTokenHelper;
        }

        [HttpPost]
        public TokenResult GenerateJwt()
        {
            var token = jwtTokenHelper.BuildAuthorizeToken(CustomSettings.AppSettings.ClientID, tokenOptions);
            return token;
        }
    }
}
