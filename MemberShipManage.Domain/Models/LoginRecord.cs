using System;
using System.Collections.Generic;

#nullable disable

namespace MemberShipManage.Server.Models
{
    public partial class LoginRecord
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime? InDate { get; set; }
    }
}
