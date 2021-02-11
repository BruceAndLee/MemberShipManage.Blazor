using MemberShipManage.Infrastructurer;
using MemberShipManage.Server.Authetication;
using MemberShipManage.Server.Filters;
using Microsoft.AspNetCore.Mvc;
using MemberShipManage.Infrastructurer.Extension;
using MemberShipManage.Shared.UserDTO;
using System.Net.Http;
using System.Net;
using MemberShipManage.Service.UserSvc;

namespace MemberShipManage.Server.Controllers
{
    [ApiController]
    [UserCreditFilter]
    [Route("[controller]/[action]")]
    public class TokenGenerateController : Controller
    {
        private readonly JWTTokenOptions tokenOptions;
        private readonly JwtTokenHelper jwtTokenHelper;
        private readonly IUserService userService;
        public TokenGenerateController(JWTTokenOptions tokenOptions
            , JwtTokenHelper jwtTokenHelper
            , IUserService userService)
        {
            this.tokenOptions = tokenOptions;
            this.jwtTokenHelper = jwtTokenHelper;
            this.userService = userService;
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
                    Content = new StringContent("user credit is invalid.")
                };
            }

            var userGetRequest = new UserGetRequest
            {
                UserNo = userCredit.UserNo,
                Password = userCredit.Password
            };

            var user = userService.GetUser(userGetRequest);
            if (user == null)
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = new StringContent("user credit is incorrect.")
                };
            }

            var token = jwtTokenHelper.BuildAuthorizeToken(CustomSettings.AppSettings.ClientID, tokenOptions);
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(token.ToJson())
            };
        }
    }
}
