using MemberShipManage.Infrastructurer;
using MemberShipManage.Repository.UserRep;
using MemberShipManage.Server.Models;
using MemberShipManage.Shared.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Service.UserSvc
{
    public class UserService : IUserService
    {
        IUserRepository respository;
        public UserService(IUserRepository respository)
        {
            this.respository = respository;
        }

        public User GetUser(UserGetRequest request)
        {
            var user = respository.GetSingle(u => u.UserNo == request.UserNo);
            if (user != null && new Cryptor().Decrypt(user.Password.ToArray()) == request.Password)
            {
                return user;
            }

            return null;
        }
    }
}
