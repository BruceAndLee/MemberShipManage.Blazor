using MemberShipManage.Server.Models;
using MemberShipManage.Shared.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Service.UserSvc
{
    public interface IUserService
    {
        User GetUser(UserGetRequest request);
    }
}
