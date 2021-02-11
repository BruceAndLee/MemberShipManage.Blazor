using MemberShipManage.Infrastructurer;
using MemberShipManage.Infrastructurer.Extension;
using MemberShipManage.Server.Authetication;
using MemberShipManage.Server.Filters;
using MemberShipManage.Service.UserSvc;
using MemberShipManage.Shared;
using MemberShipManage.Shared.UserDTO;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
        public TokenResult GenerateJwt()
        {
            var userCreditSequence = Request.Headers["user_credit"].ToString();
            var userCreditSequenceArray = userCreditSequence.Split(new char[] { ',' }).Select(u => u.Trim()).ToList();

            var userCredit = new UserCreditEntity
            {
                ClientID = userCreditSequenceArray[0],
                UserNo = userCreditSequenceArray[1],
                Password = userCreditSequenceArray[2]
            };

            if (!userCredit.ClientID.Equals(CustomSettings.AppSettings.ClientID))
            {
                return new TokenResult
                {
                    IsSuccess = false,
                    ErrorMessage = "user credit is invalid."
                };
            }

            var userGetRequest = new UserGetRequest
            {
                UserNo = userCredit.UserNo,
                Password = new Cryptor().Decrypt(userCredit.Password.ToArray())
            };

            var user = userService.GetUser(userGetRequest);
            if (user == null)
            {
                return new TokenResult
                {
                    IsSuccess = false,
                    ErrorMessage = "user credit is incorrect."
                };
            }

            return jwtTokenHelper.BuildAuthorizeToken(CustomSettings.AppSettings.ClientID, tokenOptions);
        }
    }
}
