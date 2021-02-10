using MemberShipManage.Infrastructurer;
using MemberShipManage.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Repository.UserRep
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork dbcontext)
            : base(dbcontext)
        {

        }
    }
}