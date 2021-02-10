using MemberShipManage.Infrastructurer;
using MemberShipManage.Server.Authetication;
using MemberShipManage.Server.Filters;
using Microsoft.AspNetCore.Mvc;
using MemberShipManage.Infrastructure.Extension;
using MemberShipManage.Shared.UserDTO;
using System.Net.Http;
using System.Net;

namespace MemberShipManage.Server.Controllers
{
    [ApiController]
    [AuthorizationFilter]
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
        public HttpResponseMessage GenerateJwt()
        {
            var userCreditSequence = Request.Headers["user_credit"].ToString();
            var userCredit = userCreditSequence.DeserializeFromJson<UserCreditEntity>();
            if (!userCredit.Equals(CustomSettings.AppSettings.ClientID))
            {
                return new HttpResponseMessage 
                {  
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = new StringContent("user credit is incorrect")
                };
            }

            var token = jwtTokenHelper.BuildAuthorizeToken(CustomSettings.AppSettings.ClientID, tokenOptions);
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(token)
            };
        }
    }
}
