using System;
using System.Collections.Generic;

#nullable disable

namespace MemberShipManage.Server.Models
{
    public partial class User
    {
        public string UserNo { get; set; }
        public string Password { get; set; }
        public DateTime? InDate { get; set; }
        public string InUser { get; set; }
    }
}
